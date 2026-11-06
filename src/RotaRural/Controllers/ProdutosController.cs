using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RotaRural.Data;
using RotaRural.Extensions;
using RotaRural.Models;
using RotaRural.Services;
using RotaRural.ViewModels;

namespace RotaRural.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly FotoProdutoService _fotos;

        public ProdutosController(DataBaseContext context, FotoProdutoService fotos)
        {
            _context = context;
            _fotos = fotos;
        }

        // TEMPORÁRIO: trocar pelo produtor do usuário logado quando o login existir
        private int ObterProdutorIdLogado() => 1;

        // =============== INDEX ===============
        public async Task<IActionResult> Index()
        {
            return View(await CarregarProdutosAsync());
        }

        // =============== CRIAR ===============
        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            var form = new ProdutoFormViewModel { Categorias = await CarregarCategoriasAsync() };
            return PartialView(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(ProdutoFormViewModel form)
        {
            await ValidarCategoriaAsync(form);
            ValidarFoto(form);

            if (!ModelState.IsValid)
            {
                form.Categorias = await CarregarCategoriasAsync();   // a lista não volta no POST
                return PartialView(form);
            }

            var produto = new Produto { ProdutorId = ObterProdutorIdLogado() };
            CopiarDoFormulario(form, produto);

            if (form.Foto is not null)
                produto.FotoUrl = await _fotos.SalvarAsync(form.Foto);

            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            TempData["Sucesso"] = $"\"{produto.Nome}\" foi cadastrado.";
            return RedirectToAction(nameof(Index));
        }

        // =============== EDITAR ===============
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var produto = await BuscarProdutoDoProdutorAsync(id);
            if (produto is null) return NotFound();

            var form = new ProdutoFormViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                CategoriaId = produto.CategoriaId,
                Unidade = produto.Unidade,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                AceitaRetirada = produto.AceitaRetirada,
                AceitaEntregaAgendada = produto.AceitaEntregaAgendada,
                FotoAtualUrl = produto.FotoUrl,
                Categorias = await CarregarCategoriasAsync()
            };

            return PartialView(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, ProdutoFormViewModel form)
        {
            var produto = await BuscarProdutoDoProdutorAsync(id);
            if (produto is null) return NotFound();

            await ValidarCategoriaAsync(form);
            ValidarFoto(form);

            if (!ModelState.IsValid)
            {
                form.Id = id;
                form.FotoAtualUrl = produto.FotoUrl;
                form.Categorias = await CarregarCategoriasAsync();
                return PartialView(form);
            }

            CopiarDoFormulario(form, produto);

            if (form.Foto is not null)
            {
                _fotos.Apagar(produto.FotoUrl);                      // apaga o arquivo antigo do disco
                produto.FotoUrl = await _fotos.SalvarAsync(form.Foto);
            }

            await _context.SaveChangesAsync();

            TempData["Sucesso"] = $"\"{produto.Nome}\" foi atualizado.";
            return RedirectToAction(nameof(Index));
        }

        // =============== AJUSTAR ESTOQUE ===============
        [HttpGet]
        public async Task<IActionResult> AjustarEstoque(int id)
        {
            var produto = await BuscarProdutoDoProdutorAsync(id);
            if (produto is null) return NotFound();

            return PartialView(MontarAjusteEstoque(produto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjustarEstoque(int id, AjustarEstoqueViewModel form)
        {
            var produto = await BuscarProdutoDoProdutorAsync(id);
            if (produto is null) return NotFound();

            if (!ModelState.IsValid)
                return PartialView(MontarAjusteEstoque(produto, form.NovaQuantidade));

            produto.DefinirEstoque(form.NovaQuantidade!.Value);
            await _context.SaveChangesAsync();

            TempData["Sucesso"] =
                $"Estoque de \"{produto.Nome}\" atualizado para {produto.Quantidade} {produto.Unidade.NomeExibicao()}.";
            return RedirectToAction(nameof(Index));
        }

        // =============== REMOVER ===============
        [HttpGet]
        public async Task<IActionResult> Remover(int id)
        {
            var produto = await BuscarProdutoDoProdutorAsync(id);
            if (produto is null) return NotFound();

            return PartialView(produto);
        }

        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverConfirmado(int id)
        {
            var produto = await BuscarProdutoDoProdutorAsync(id);
            if (produto is null) return NotFound();

            produto.Excluir();
            await _context.SaveChangesAsync();

            TempData["Sucesso"] = $"\"{produto.Nome}\" foi removido.";
            return RedirectToAction(nameof(Index));
        }

        // =============== AUXILIARES ===============

        // Só encontra o produto se ele for do produtor logado (e não estiver excluído, pelo filtro global)
        private async Task<Produto?> BuscarProdutoDoProdutorAsync(int id)
        {
            var produtorId = ObterProdutorIdLogado();
            return await _context.Produto
                .FirstOrDefaultAsync(p => p.Id == id && p.ProdutorId == produtorId);
        }

        // Copia os campos do formulário para a entidade (usado no Criar e no Editar)
        private static void CopiarDoFormulario(ProdutoFormViewModel form, Produto produto)
        {
            produto.Nome = form.Nome.Trim();
            produto.CategoriaId = form.CategoriaId!.Value;
            produto.Unidade = form.Unidade!.Value;
            produto.Preco = form.Preco!.Value;
            produto.AceitaRetirada = form.AceitaRetirada;
            produto.AceitaEntregaAgendada = form.AceitaEntregaAgendada;
            produto.DefinirEstoque(form.Quantidade!.Value);
        }

        private static AjustarEstoqueViewModel MontarAjusteEstoque(Produto produto, int? novaQuantidade = null)
        {
            return new AjustarEstoqueViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Unidade = produto.Unidade.NomeExibicao(),
                QuantidadeAtual = produto.Quantidade,
                NovaQuantidade = novaQuantidade ?? produto.Quantidade
            };
        }

        private async Task<List<Produto>> CarregarProdutosAsync()
        {
            var produtorId = ObterProdutorIdLogado();

            return await _context.Produto
                .Include(p => p.Categoria)
                .Where(p => p.ProdutorId == produtorId)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        private async Task<List<SelectListItem>> CarregarCategoriasAsync()
        {
            return await _context.CategoriasProduto
                .Where(c => c.Ativa)
                .OrderBy(c => c.Nome)
                .Select(c => new SelectListItem(c.Nome, c.Id.ToString()))
                .ToListAsync();
        }

        // Garante que a categoria enviada existe e está ativa (o select pode ser adulterado pelo F12)
        private async Task ValidarCategoriaAsync(ProdutoFormViewModel form)
        {
            if (form.CategoriaId is null) return;

            var existe = await _context.CategoriasProduto
                .AnyAsync(c => c.Id == form.CategoriaId && c.Ativa);

            if (!existe)
                ModelState.AddModelError(nameof(form.CategoriaId), "Categoria inválida.");
        }

        private void ValidarFoto(ProdutoFormViewModel form)
        {
            if (form.Foto is null) return;

            var erro = _fotos.Validar(form.Foto);
            if (erro is not null)
                ModelState.AddModelError(nameof(form.Foto), erro);
        }
    }
}
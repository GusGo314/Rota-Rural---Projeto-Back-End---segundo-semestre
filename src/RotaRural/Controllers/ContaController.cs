using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RotaRural.Data;
using RotaRural.Models;
using RotaRural.ViewModels.Conta;
using System.Security.Claims;

namespace RotaRural.Controllers;

/// <summary>
/// Login local: valida a senha contra <see cref="Usuario.SenhaHash"/> e emite um cookie.
/// Adaptado do fluxo da branch feature/RF01-Full, que usava ASP.NET Identity.
/// </summary>
public class ContaController : Controller
{
    private readonly DataBaseContext _context;
    private readonly IPasswordHasher<Usuario> _hasher;
    private readonly ILogger<ContaController> _logger;

    public ContaController(
        DataBaseContext context,
        IPasswordHasher<Usuario> hasher,
        ILogger<ContaController> logger)
    {
        _context = context;
        _hasher = hasher;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Produtos");
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var email = model.Email.Trim();
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

        if (usuario != null)
        {
            var verificacao = _hasher.VerifyHashedPassword(usuario, usuario.SenhaHash, model.Senha);

            if (verificacao != PasswordVerificationResult.Failed)
            {
                // Hash gerado por parâmetros antigos: regrava com os atuais
                if (verificacao == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    usuario.SenhaHash = _hasher.HashPassword(usuario, model.Senha);
                    await _context.SaveChangesAsync();
                }

                await EntrarAsync(usuario);
                _logger.LogInformation("Login do usuário {Id}.", usuario.Id);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Produtos");
            }
        }

        ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos.");
        return View(model);
    }

    [HttpGet]
    public async Task <IActionResult> Cadastro()
    {
        var model = new CadastroViewModel();
        await CarregarMunicipiosAsync(model);
        return View(model);
    }

    private async Task CarregarMunicipiosAsync(CadastroViewModel model)
    {
        model.Municipios = await _context.Microrregioes
            .OrderBy(m => m.nomeMunicipio)
            .Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.nomeMunicipio
            })
            .ToListAsync();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cadastro(CadastroViewModel model)
    {
        var ehProdutor = string.Equals(model.Perfil, Perfis.Produtor, StringComparison.OrdinalIgnoreCase);
        var ehComprador = string.Equals(model.Perfil, Perfis.Comprador, StringComparison.OrdinalIgnoreCase);

        if (!ehProdutor && !ehComprador)
        {
            var administrador = string.Equals(model.Perfil, Perfis.Administrador, StringComparison.OrdinalIgnoreCase);

            ModelState.AddModelError(string.Empty, administrador
                ? "Contas de administrador são criadas internamente pela equipe Rota Rural."
                : "Tipo de conta inválido.");

            return View(model);
        }

        // Campos que só existem para quem vende
        if (ehProdutor)
        {
            if (string.IsNullOrWhiteSpace(model.NomeUnidadeFamiliar))
            {
                ModelState.AddModelError(nameof(model.NomeUnidadeFamiliar), "Informe o nome da unidade familiar.");
            }

            if (string.IsNullOrWhiteSpace(model.Caf))
            {
                ModelState.AddModelError(nameof(model.Caf), "Informe o número do CAF.");
            }
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var cpf = CpfHelper.Formatar(model.Cpf);
        var email = model.Email.Trim();

        var municipio = model.MicrorregiaoId;

        




        if (await _context.Produtores.AnyAsync(p => p.Cpf == cpf)
            || await _context.Compradores.AnyAsync(c => c.Cpf == cpf))
        {
            ModelState.AddModelError(nameof(model.Cpf), "Já existe uma conta com este CPF.");
            return View(model);
        }

        if (await _context.Usuarios.AnyAsync(u => u.Email == email))
        {
            ModelState.AddModelError(nameof(model.Email), "Já existe uma conta com este e-mail.");
            return View(model);
        }

        return ehProdutor
            ? await CadastrarProdutorAsync(model, cpf, email)
            : await CadastrarCompradorAsync(model, cpf, email);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Sair()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Produtos");
    }

    [HttpGet]
    public IActionResult AcessoNegado()
    {
        return View();
    }

    private async Task<IActionResult> CadastrarProdutorAsync(CadastroViewModel model, string cpf, string email)
    {
        if (string.IsNullOrWhiteSpace(model.Endereco))
        {
            ModelState.AddModelError(nameof(model.Endereco), "Informe o endereço da propriedade.");
            return View(model);
        }

        // TODO: derivar do município do endereço quando a carga do IBGE existir.
        var microrregiao = await _context.Microrregioes.OrderBy(m => m.Id).FirstOrDefaultAsync();

        var produtor = new Produtor
        {
            Nome = model.Nome.Trim(),
            Email = email,
            Cpf = cpf,
            NomeUnidadeFamiliar = (model.NomeUnidadeFamiliar ?? string.Empty).Trim(),
            Caf = (model.Caf ?? string.Empty).Trim(),
            RegistroIma = string.IsNullOrWhiteSpace(model.Ima) ? null : model.Ima.Trim(),
            EnderecoPropriedade = model.Endereco.Trim(),
            StatusAprovacao = StatusAprovacao.Pendente,
            MicrorregiaoId = microrregiao?.Id
        };

        produtor.SenhaHash = _hasher.HashPassword(produtor, model.Senha);

        if (!await SalvarAsync(produtor))
        {
            return View(model);
        }

        TempData["Sucesso"] =
            "Cadastro enviado! Seu perfil de produtor está pendente até a aprovação do administrador.";
        return RedirectToAction(nameof(Login));
    }

    private async Task<IActionResult> CadastrarCompradorAsync(CadastroViewModel model, string cpf, string email)
    {
        var comprador = new Comprador
        {
            Nome = model.Nome.Trim(),
            Email = email,
            Cpf = cpf,
            Endereco = string.IsNullOrWhiteSpace(model.Endereco) ? null : model.Endereco.Trim()
        };

        comprador.SenhaHash = _hasher.HashPassword(comprador, model.Senha);

        if (!await SalvarAsync(comprador))
        {
            return View(model);
        }

        // Comprador não depende de aprovação: já entra logado
        await EntrarAsync(comprador);
        return RedirectToAction("Index", "Produtos");
    }

    private async Task<bool> SalvarAsync(Usuario usuario)
    {
        try
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogWarning(ex, "Falha ao gravar cadastro.");
            ModelState.AddModelError(string.Empty,
                "Não foi possível concluir o cadastro. Verifique se o CPF e o e-mail já não estão cadastrados.");
            return false;
        }
    }

    private async Task EntrarAsync(Usuario usuario)
    {
        var perfil = usuario switch
        {
            Produtor => Perfis.Produtor,
            Comprador => Perfis.Comprador,
            _ => Perfis.Administrador
        };

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new(ClaimTypes.Name, usuario.Nome),
            new(ClaimTypes.Email, usuario.Email),
            new(ClaimTypes.Role, perfil)
        };

        // Usado pelo _LayoutProdutor para exibir a unidade familiar
        if (usuario is Produtor produtor)
        {
            claims.Add(new Claim("UnidadeFamiliar", produtor.NomeUnidadeFamiliar));
        }

        var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identidade));
    }
}

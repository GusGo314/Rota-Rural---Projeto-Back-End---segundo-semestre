namespace RotaRural.Services
{
    public class FotoProdutoService
    {
        private static readonly string[] Extensoes = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long TamanhoMaximo = 2 * 1024 * 1024; // 2 MB

        private readonly IWebHostEnvironment _env;

        public FotoProdutoService(IWebHostEnvironment env) => _env = env;

        // Devolve a mensagem de erro, ou null se a foto for válida
        public string? Validar(IFormFile foto)
        {
            var ext = Path.GetExtension(foto.FileName).ToLowerInvariant();
            if (!Extensoes.Contains(ext)) return "Envie uma imagem JPG, PNG ou WEBP.";
            if (foto.Length > TamanhoMaximo) return "A imagem deve ter no máximo 2 MB.";
            return null;
        }

        // Salva em wwwroot/uploads/produtos e devolve o caminho para guardar no banco
        public async Task<string> SalvarAsync(IFormFile foto)
        {
            var ext = Path.GetExtension(foto.FileName).ToLowerInvariant();
            var pasta = Path.Combine(_env.WebRootPath, "uploads", "produtos");
            Directory.CreateDirectory(pasta);

            var nomeArquivo = $"{Guid.NewGuid():N}{ext}";
            await using var stream = File.Create(Path.Combine(pasta, nomeArquivo));
            await foto.CopyToAsync(stream);

            return $"/uploads/produtos/{nomeArquivo}";
        }

        // Apaga o arquivo físico de uma foto antiga
        public void Apagar(string? url)
        {
            if (string.IsNullOrEmpty(url)) return;

            var caminho = Path.Combine(_env.WebRootPath, url.TrimStart('/'));
            if (File.Exists(caminho)) File.Delete(caminho);
        }
    }
}
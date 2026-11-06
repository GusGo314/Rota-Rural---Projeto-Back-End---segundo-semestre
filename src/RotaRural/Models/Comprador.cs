using System.ComponentModel.DataAnnotations;

namespace RotaRural.Models
{
    /// <summary>
    /// Quem compra: não tem propriedade rural, portanto não tem microrregião.
    /// Fica na mesma tabela de Usuario (TPH), distinguido pela coluna Discriminator.
    /// </summary>
    public class Comprador : Usuario
    {
        // Mesmos atributos de Produtor.Cpf: em TPH as duas propriedades compartilham a coluna
        [Required, StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Endereco { get; set; }
    }
}

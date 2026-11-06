using System.ComponentModel.DataAnnotations;

namespace RotaRural.Models
{
    /// <summary>
    /// Município e sua hierarquia territorial do IBGE (uma linha por município).
    /// </summary>
    public class Microrregiao
    {
       
        public int Id { get; set; }
        [Required]
        public string nomeMunicipio { get; set; } = string.Empty;
        
        public int CodigoMunicipioIbge { get; set; }
    
    }
}

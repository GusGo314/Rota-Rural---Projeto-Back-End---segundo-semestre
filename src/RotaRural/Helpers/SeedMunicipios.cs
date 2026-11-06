using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotaRural.Data;
using RotaRural.Extensions;
using RotaRural.Models;
using RotaRural.Services;
using RotaRural.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace RotaRural.Helpers
{





        public class SeedMunicipios
    {

        private readonly DataBaseContext _context;
   

        public SeedMunicipios(DataBaseContext context)
        {
            _context = context;
           
        }



        public static List<Municipio> ListaGlobal { get; set; } = new();
        public class Municipio
        {

            [JsonPropertyName("id")]
            public int IdMunicipio { get; set; }
            [JsonPropertyName("nome")]
            public string NomeMunicipio { get; set; } = string.Empty;

        }



        public  async Task RequisitarDados()
            {
                using var requisicao = new HttpClient();
                var url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/31/municipios";

                var resposta = await requisicao.GetAsync(url);

                if (resposta.IsSuccessStatusCode)
                {

                    var json = await resposta.Content.ReadAsStringAsync();
                  
                  ListaGlobal =  JsonSerializer.Deserialize<List<Municipio>>(json) ?? new();



                }
                  foreach (var municipio in ListaGlobal)
            {
                var Populado = await _context.Microrregioes.AnyAsync(m => m.CodigoMunicipioIbge == municipio.IdMunicipio);

                if (Populado)
                    continue;
                _context.Microrregioes.Add (new Microrregiao
                {
                  
                    nomeMunicipio = municipio.NomeMunicipio,
                    CodigoMunicipioIbge = municipio.IdMunicipio
                });

            }
            await _context.SaveChangesAsync();

            } 





        



    }
}

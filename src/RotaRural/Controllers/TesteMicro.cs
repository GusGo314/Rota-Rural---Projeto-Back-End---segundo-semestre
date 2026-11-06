using Microsoft.AspNetCore.Mvc;
using RotaRural.Helpers;
using RotaRural.Models;
namespace RotaRural.Controllers
{
    public class TesteMicro : Controller
    {
        public async Task<IActionResult> MicroRegiao()
        {
            var municipios =  SeedMunicipios.ListaGlobal;







            return View(municipios);
        }
    }
}

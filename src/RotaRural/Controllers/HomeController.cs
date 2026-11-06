using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RotaRural.Models;

namespace RotaRural.Controllers;

public class HomeController : Controller
{
    /// <summary>
    /// Porta de entrada: visitante vê o formulário de login;
    /// usuário autenticado vai direto para a página de produtos.
    /// </summary>
    public IActionResult Index()
    {
        return User.Identity?.IsAuthenticated == true
            ? RedirectToAction("Index", "Produtos")
            : RedirectToAction("Login", "Conta");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValidations.Models;

namespace DojoSurveyValidations.Controllers;

public class HomeController : Controller
{
    public static Ninja NewNinja;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult FormView()
    {
        return View("FormView");
    }

    [HttpPost("user/create")]
    public IActionResult CreateNinja (Ninja ninja)
    {
        NewNinja= ninja;
        // return RedirectToAction("ResultsView");
        //validation logic
        if (ModelState.IsValid)
        {
            return RedirectToAction("ResultsView");
        }
        else
        {
            return View ("FormView");
        }
    }

    [HttpGet("results")]
    public IActionResult ResultsView()
    {
        return View(NewNinja);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

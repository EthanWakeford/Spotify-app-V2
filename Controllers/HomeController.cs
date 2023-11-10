using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using v2_spotify_app.Models;
using v2_spotify_app.SpotifyApiController;

namespace v2_spotify_app.Controllers;


public class HomeController : Controller
{
    static readonly Config config = new Config();
    private readonly ILogger<HomeController> _logger;
    private Spotify _spotify;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _spotify = new Spotify(config.clientId, config.clientSecret);
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.id = _spotify.clientId;
        ViewBag.token = await _spotify.CreateToken();
        return View();
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

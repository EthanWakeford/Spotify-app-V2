using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using v2_spotify_app.Models;
using v2_spotify_app.SpotifyApiController;

namespace v2_spotify_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Spotify _spotify;

    public HomeController(ILogger<HomeController> logger)
    {
        // loading dotenv file in ENV
        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");
        DotEnv.Load(dotenv);

        var clientId = System.Environment.GetEnvironmentVariable("CLIENT_ID");
        var clientSecret = System.Environment.GetEnvironmentVariable("CLIENT_SECRET");

        _logger = logger;
        _spotify = new Spotify(clientId, clientSecret);
    }

    public IActionResult Index()
    {
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

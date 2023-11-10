using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using v2_spotify_app.Models;
using v2_spotify_app.SpotifyApiController;

namespace v2_spotify_app.Controllers;


public class HomeController : Controller
{
    static readonly string? clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
    static readonly string? clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
    private readonly ILogger<HomeController> _logger;
    private Spotify _spotify;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        // loading dotenv file in ENV
        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");
        DotEnv.Load(dotenv);

        if (clientId is null || clientSecret is null) throw new Exception("one or more spotify client credentials are null");
        _spotify = new Spotify(clientId, clientSecret);
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

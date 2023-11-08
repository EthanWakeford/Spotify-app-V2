// class for interfacing with the spotify REST API

namespace v2_spotify_app.SpotifyApiController;

public class SpotifyHttpClient : HttpClient
{
    public SpotifyHttpClient()
    {
        BaseAddress = new Uri("https://accounts.spotify.com/api");

    }
}

public class Spotify
{

    public readonly string clientId;
    public readonly string clientSecret;
    public Spotify(string clientId, string clientSecret)
    {
        this.clientId = clientId;
        this.clientSecret = clientSecret;
    }

    // public async string CreateAuthCode()
    // {
    //     // creates an auth code with spotify API oauth auth code flow
    //     const string url = "https://accounts.spotify.com/api/token";
    //     // const Dictionary<string, string> headers = new Dictionary<string, string>() { { "Content-Type", "application/x-www-form-urlencoded" } };
    //     var client = new HttpClient();
    // var message = new HttpRequestMessage();
    //     return;
    // }
}

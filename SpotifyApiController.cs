// class for interfacing with the spotify REST API

namespace v2_spotify_app.SpotifyApiController;

public class SpotifyHttpClient : HttpClient
{
    public SpotifyHttpClient()
    {
        // BaseAddress = new Uri("https://accounts.spotify.com/api");
        DefaultRequestHeaders.Clear();
    }
}

public class Spotify
{

    public readonly string clientId;
    public readonly string clientSecret;
    private static readonly SpotifyHttpClient spotifyClient = new SpotifyHttpClient();


    public Spotify(string clientId, string clientSecret)
    {
        this.clientId = clientId;
        this.clientSecret = clientSecret;
    }

    public async Task<string?> CreateAuthCode()
    {
        // creates an auth code with spotify API oauth auth code flow
        const string uri = "https://accounts.spotify.com/api/token";

        var postData = new Dictionary<string, string>{
            {"grant_type", "client_credentials"},
            {"client_id", clientId},
            {"client_secret", clientSecret},
        };

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(uri))
        {
            Content = new FormUrlEncodedContent(postData)
        };

        HttpResponseMessage response = await spotifyClient.SendAsync(requestMessage);
        string? responseString = await response.Content.ReadAsStringAsync();

        // debugging stuff, remove later
        Console.WriteLine($"the whole response object: {response}");
        Console.WriteLine($"response content: {responseString}");

        if (responseString == null)
        {
            return $"it broke, here's why {response.StatusCode}";
        }
        return responseString;
    }

    // public async Task<string?> getArtist()
}

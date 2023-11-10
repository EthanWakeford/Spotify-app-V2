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
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(uri));
        requestMessage.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

        HttpResponseMessage response = await spotifyClient.SendAsync(requestMessage);

        Console.WriteLine(response.StatusCode.ToString(), response);

        Console.WriteLine(response.Content.ToString());
        // var response = await 
        var responseString = response.Content.ToString();

        if (responseString == null)
        {
            return $"it broke, here's why {response.StatusCode}";
        }
        return response.Content.ToString();
    }

    // public async Task<string?> getArtist()
}

// class for interfacing with the spotify REST API

using System.Text.Json;

namespace v2_spotify_app.SpotifyApiController;

public class SpotifyHttpClient : HttpClient
{
    public SpotifyHttpClient()
    {
        BaseAddress = new Uri("https://accounts.spotify.com/api/");
        DefaultRequestHeaders.Clear();
    }
}

public class Spotify
{

    private static readonly SpotifyHttpClient spotifyClient = new SpotifyHttpClient();
    public readonly string clientId;
    public readonly string clientSecret;
    private string? token;
    private string? scopedToken;


    public Spotify(string clientId, string clientSecret)
    {
        this.clientId = clientId;
        this.clientSecret = clientSecret;
    }

    private async Task<string> handleErr(HttpResponseMessage response)
    {
        var err = await response.Content.ReadAsStringAsync();
        return $"it broke, here's why {response.StatusCode}: {err} ";
    }

    /// <summary>
    /// creates an auth code with spotify API oauth auth code flow
    /// </summary>
    /// <returns> @string: token string</returns>
    public async Task<string> CreateToken()
    {
        const string uri = "token";
        var postData = new Dictionary<string, string>{
            {"grant_type", "client_credentials"},
            {"client_id", clientId},
            {"client_secret", clientSecret},
        };

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = new FormUrlEncodedContent(postData)
        };

        HttpResponseMessage response = await spotifyClient.SendAsync(requestMessage);
        if (!response.IsSuccessStatusCode) return await handleErr(response);

        string? responseString = await response.Content.ReadAsStringAsync();

        var resData = JsonSerializer.Deserialize<TokenJson>(responseString);
        if (resData is null) return await handleErr(response);

        token = resData.access_token;

        if (token is null) return $"token is null, I have no idea why";

        // debugging stuff, remove later
        Console.WriteLine($"response content: {resData}");
        Console.WriteLine($"token: {token}");
        return token;
    }

    // public async Task<string?>
}

public class TokenJson
{
    public string? access_token { get; set; }
    public string? token_type { get; set; }
    public int? expires_in { get; set; }

}

// class for interfacing with the spotify REST API

namespace v2_spotify_app.SpotifyApiController;
public class Spotify
{

    public readonly string clientId;
    public readonly string clientSecret;
    public Spotify(string clientId, string clientSecret)
    {
        this.clientId = clientId;
        this.clientSecret = clientSecret;
    }
}

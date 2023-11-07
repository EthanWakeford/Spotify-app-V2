// class for interfacing with the spotify REST API

namespace v2_spotify_app.SpotifyApiController;
public class Spotify
{

    private readonly string _clientId;
    private readonly string _clientSecret;
    public Spotify(string clientId, string clientSecret)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
    }
}

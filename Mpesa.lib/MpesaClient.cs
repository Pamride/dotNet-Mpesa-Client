using System.Text;
using System.Text.Json;
using Mpesa.lib.Enums;
using Mpesa.lib.Extension;
using Mpesa.lib.Routes;


namespace Mpesa.lib;

public class MpesaHttpClient : Services.IMpesa
{
    private HttpClient _httpclient;
    private Env Enviroment;
    private string _consumerKey;
    private string _consumerSecret;
    private ICredentials _credentials;


    public HttpClient Client {
        get {
            return _httpclient;
        }
    }

    private AuthResponse _auth;

    public AuthResponse Auth
    {
        get
        {
            if (_auth is not null) return _auth;
            return RequestAccessToken().GetAwaiter().GetResult();
        }
    }

    public MpesaHttpClient(string consumerSecret, string consumerKey, ICredentials credentials, Env enviroment = Env.Sandbox)
    {
        _consumerKey = consumerKey;
        _consumerSecret = consumerSecret;
        Enviroment = enviroment;
         _credentials = credentials;
        CreateMpesaClient(Enviroment.ToDescription()).GetAwaiter().GetResult();
    }


    private async Task CreateMpesaClient(string baseurl)
    {
        _httpclient = new HttpClient()
        {
            BaseAddress = new Uri(baseurl)
        };
        updateClientHeaderAccessToken(await RequestAccessToken());
    }

    private async Task<AuthResponse> RequestAccessToken()
    {
        byte[] creds = Encoding.UTF8.GetBytes(_consumerSecret + ":" + _consumerKey);
        String encoded = System.Convert.ToBase64String(creds);
        _httpclient?.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
        var response = await _httpclient.GetStreamAsync(MpesaRoute.Client_Crendetial);
        return await JsonSerializer.DeserializeAsync<AuthResponse>(response);
    }

    private void updateClientHeaderAccessToken(AuthResponse response)
    {
        _httpclient.DefaultRequestHeaders.Remove("Authorization");
        _httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + response.AccessToken);
    }
}


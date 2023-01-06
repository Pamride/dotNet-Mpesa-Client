using System.Text;
using System.Text.Json;
using System.Timers;
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

    private static System.Timers.Timer aTimer = new System.Timers.Timer();
    

    public HttpClient Client {
        get {
            return _httpclient;
        }
    }

    public MpesaHttpClient(string consumerSecret, string consumerKey, ICredentials credentials, Env enviroment = Env.Sandbox)
    {
        _consumerKey = consumerKey;
        _consumerSecret = consumerSecret;
        Enviroment = enviroment;
         _credentials = credentials;
        CreateMpesaClient(Enviroment.ToDescription()).GetAwaiter().GetResult();
        aTimer.Elapsed += OnTimedEvent;
    }

    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
       UpdateAuthorizationToken((GetTokenAsync().GetAwaiter().GetResult()).AccessToken);
    }

    private async Task CreateMpesaClient(string baseurl)
    {
        _httpclient = new HttpClient()
        {
            BaseAddress = new Uri(baseurl)
        };
        AuthResponse tokenresponse = await GetTokenAsync();
        UpdateAuthorizationToken(tokenresponse.AccessToken);
        UpdateTimerRefreshInterval(aTimer, tokenresponse.Expiration);
    }
    

    private async Task<AuthResponse> GetTokenAsync() {
        byte[] creds = Encoding.UTF8.GetBytes(_consumerSecret + ":" + _consumerKey);
        String encoded = System.Convert.ToBase64String(creds);
        _httpclient?.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
        return await JsonSerializer.DeserializeAsync<AuthResponse>(await _httpclient.GetStreamAsync(MpesaRoute.Client_Crendetial));
    }

    private  void UpdateAuthorizationToken(string accesstoken){
              _httpclient.DefaultRequestHeaders.Remove("Authorization");
              _httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accesstoken);
    }

    private void UpdateTimerRefreshInterval(System.Timers.Timer timer, string interval)
    {
         timer.Interval = Double.Parse(interval) * 1000;
    }

}


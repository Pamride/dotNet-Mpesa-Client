using System.Text;
using System.Text.Json;
using mpesa.lib.Enums;
using Mpesa.lib.Extension;
using Mpesa.lib.Routes;
using Mpesa.lib.Services;

namespace Mpesa.lib;

public class MpesaHttpClient : IHttpClient
{
    private HttpClient _httpclient;
    private Env Enviroment;
    private string _consumerKey;
    private string _consumerSecret;

    public MpesaHttpClient( string consumerSecret, string consumerKey, Env enviroment = Env.Sandbox)
    {
        _consumerKey = consumerKey;
        _consumerSecret = consumerSecret;
        Enviroment = enviroment;
        _httpclient = CreateMpesaClient(Enviroment.ToDescription());
    }

    


    private HttpClient CreateMpesaClient(string baseurl)
    {
        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri(baseurl)
        };
        return client;
    }

    private async Task<AuthResponse> RequestAccessToken()
    {
        byte[] creds = Encoding.UTF8.GetBytes(_consumerKey + ":" + _consumerKey);
        String encoded = System.Convert.ToBase64String(creds);
        _httpclient?.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
        var streamTask = _httpclient.GetStreamAsync(MpesaRoute.Client_Crendetial);
        return await JsonSerializer.DeserializeAsync<AuthResponse>(await streamTask);
    }

    public async Task updateClientHeaderAccessToken()
    {
        AuthResponse response = await RequestAccessToken();
        _httpclient.DefaultRequestHeaders.Add("Authorization","Bearer " + response.AccessToken);
    }
}


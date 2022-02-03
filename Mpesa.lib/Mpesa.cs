using mpesa.lib.Enums;
using mpesa.lib.Models;

namespace Mpesa.lib;


public class MpesaClient : IMpesa
{
    private readonly HttpClient _httpClient;
    private readonly ICredentials _credentials;

    public MpesaClient(HttpClient httpClient, ICredentials credentials)
    {
        httpClient = _httpClient;
        _credentials = credentials;
    }

    public Task<AccountBalanceResponse> AccountBalanceAsync(IdentityParty partyA, string queueUrl, string resultUrl, string remarks = "Checking account balance")
    {
        if(partyA.Type != IdentifierType.SHORTCODE) throw new Exception("Account Balance only for shortcodes");
        throw new NotImplementedException();
    }

  }


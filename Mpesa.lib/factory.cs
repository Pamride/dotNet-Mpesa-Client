using Mpesa.lib.Enums;
using mpesa.lib.settings;
using Mpesa.lib;
using Mpesa.Features;
using Mpesa.lib.Services;

namespace Mpesa.Factory;

public static class factory {
   
  public static Mpesa.lib.Services.IMpesa CreateMpesaClient(IConfig config, Env enviroment ) {

     HttpClient client = new HttpClient();
     ICredentials creds= new Credentials();
    IMpesa  mclient= new MpesaHttpClient(config.ConsumerSecret, config.ConsumerKey, creds, enviroment);

     return mclient;
  }

  public static LipaNaMpesaRequest CreateLipaNaMpesaRequest(IConfig config) 
{
    return new LipaNaMpesaRequest {
      BusinessShortCode = config.BusinessShortCode,
      Timestamp = config.Timestamp,
      PartyB = config.BusinessShortCode,
      CallBackURL = config.CallBackURL,
      AccountReference = config.AccountReference,
      Password = config.Password,
    };
}

  public static LipaNaMpesaQueryRequest CreateLipaNaMpesaStatusRequest(IConfig config) 
{
    return new LipaNaMpesaQueryRequest  {
      BusinessShortCode = config.BusinessShortCode,
      Timestamp = config.Timestamp,
      Password = config.Password,
    };
}
}


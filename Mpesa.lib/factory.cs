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
      Password = "MTc0Mzc5YmZiMjc5ZjlhYTliZGJjZjE1OGU5N2RkNzFhNDY3Y2QyZTBjODkzMDU5YjEwZjc4ZTZiNzJhZGExZWQyYzkxOTIwMTYwMjE2MTY1NjI3",
      PartyB = config.BusinessShortCode,
      CallBackURL = config.CallBackURL,
      AccountReference = config.AccountReference,
    };
}
}


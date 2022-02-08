using mpesa.lib.Enums;
using mpesa.lib.settings;
using Mpesa.lib;
using Mpesa.lib.Services;

namespace Mpesa.Factory;

public static class factory {
   
  public static Mpesa.lib.Services.IMpesa CreateMpesaClient(IConfig config, Env enviroment ) {

     HttpClient client = new HttpClient();
     ICredentials creds= new Credentials();

        Mpesa.lib.Services.IMpesa  mclient= new MpesaHttpClient(config.ConsumerSecret, config.ConsumerSecret, creds, enviroment);


     return mclient;
  }

}


using Mpesa.lib;

public static class factory {
   
  public static IMpesa CreateMpesaClient() {
     
     HttpClient client = new HttpClient();
     ICredentials creds= new Credentials();
     IMpesa  mclient= new MpesaClient(client, creds);
     return mclient;
  }

}


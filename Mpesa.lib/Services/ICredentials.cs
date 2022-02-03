namespace Mpesa.lib;

public interface ICredentials {
  Task<string> GetSecurityCredentialsAsync();  
}

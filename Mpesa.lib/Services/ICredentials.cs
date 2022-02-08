using mpesa.lib.settings;

namespace Mpesa.lib;

public interface ICredentials {
  string GetSecurityCredentialsAsync(IConfig config);  
}

using Mpesa.Lib.Settings;

namespace Mpesa.Lib;

public interface ICredentials
{
    string GetSecurityCredentialsAsync(IConfig config);
}

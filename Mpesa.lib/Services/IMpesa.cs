using mpesa.lib.Models;

namespace Mpesa.lib;

public interface IMpesa {
   Task<AccountBalanceResponse> AccountBalanceAsync(IdentityParty partyA, string queueUrl, string resultUrl, string remarks = "Checking account balance");
}

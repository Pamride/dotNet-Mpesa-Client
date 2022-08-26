
namespace Mpesa.Lib.Routes;

public static class MpesaRoute
{
    public static string BaseAddress = "base address";
    public static string Client_Crendetial = "oauth/v1/generate?grant_type=client_credentials";
    public static string LipaNa_MpesaOnline = "mpesa/stkpush/v1/processrequest";
    public static string LipaNa_MpesaOnlineStatus = "mpesa/stkpushquery/v1/query";
    public static string B2CUri = "mpesa/b2c/v1/paymentrequest";
    public static string B2CUriStatus = "";
}

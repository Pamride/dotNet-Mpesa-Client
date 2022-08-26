using Mpesa.Lib.Enums;
using Mpesa.Lib.Settings;
using Mpesa.Lib;
using Mpesa.Features;
using Mpesa.Lib.Services;

namespace Mpesa.Factory;

public static class factory
{
    public static Mpesa.Lib.Services.IMpesa CreateMpesaClient(IConfig config, Env enviroment)
    {
        HttpClient client = new HttpClient();
        ICredentials creds = new Credentials();
        IMpesa mclient = new MpesaHttpClient(config.ConsumerSecret!, config.ConsumerKey!, creds, enviroment);
        return mclient;
    }


    #region LipaNaMpesaOnline
    
    public static LipaNaMpesaRequest CreateLipaNaMpesaRequest(IConfig config)
    {
        return new LipaNaMpesaRequest
        {
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
        return new LipaNaMpesaQueryRequest
        {
            BusinessShortCode = config.BusinessShortCode,
            Timestamp = config.Timestamp,
            Password = config.Password,
        };
    }

    #endregion


    #region B2C

    public static B2CRequest CreateB2CRequest(IConfig config)
    {
        return new B2CRequest
        {
            InitiatorName = config.Initiator,
            SecurityCredential = config.SecurityCredential,
            PartyB = config.BusinessShortCode
        };

    }

    public static B2CStatusRequest CreateB2CStatusRequest(IConfig config)
    {
        return new B2CStatusRequest
        {

        };
    }

    #endregion
}


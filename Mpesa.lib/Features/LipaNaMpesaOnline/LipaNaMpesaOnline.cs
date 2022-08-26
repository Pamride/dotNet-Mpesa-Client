using Mpesa.Lib.Enums;
using System.Text;
using System.Text.Json;
using Mpesa.Lib.Routes;
using Mpesa.Lib.Services;
using System.Text.Json.Serialization;

namespace Mpesa.Features;

public class LipaNaMpesaRequest 
{
    public string? BusinessShortCode { get; set; }
    public string? Password { get; set; }
    public string? Timestamp { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CommandType TransactionType { get; set; } = CommandType.CustomerPayBillOnline;
    public string? Amount { get; set; }
    public string? PartyA { get; set; }
    public string? PartyB { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CallBackURL { get; set; }
    public string? AccountReference { get; set; }
    public string? TransactionDesc { get; set; } // e.g. "Pay for you car ride fare";
}

public class LipaNaMpesaResponse : IResponse
{      public string? MerchantRequestID { get; set; }
        public string? CheckoutRequestID { get; set; }
        public string? ResponseCode { get; set; }
        public string? ResponseDescription { get; set; }
        public string? CustomerMessage { get; set; }
} 

public static class LipaNaMpesaOnline
{
    public static async Task<IResponse> LipaNaMpesaOnlineAsync(this IMpesa mpesaclient, LipaNaMpesaRequest lipanampesaonlinerequest)
    {
        var payload = JsonSerializer.Serialize(lipanampesaonlinerequest);
        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await mpesaclient.Client.PostAsync(MpesaRoute.LipaNa_MpesaOnline, c);
        Stream? responseContent = await response.Content.ReadAsStreamAsync();
        LipaNaMpesaResponse? responseJson = await JsonSerializer.DeserializeAsync<LipaNaMpesaResponse>(responseContent);
        return responseJson!;
    }
}

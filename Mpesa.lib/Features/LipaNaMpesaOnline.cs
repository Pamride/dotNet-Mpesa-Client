using Mpesa.lib.Enums;
using System.Text;
using System.Text.Json;
using Mpesa.lib;
using Mpesa.lib.Routes;
using Mpesa.lib.Services;
using System.Text.Json.Serialization;

namespace Mpesa.Features;

public class LipaNaMpesaRequest
{
  public string? BusinessShortCode { get; set; }
  public string? Password { get; set; }
  public string? Timestamp { get; set; } = DateTime.Now.ToString();
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public CommandType TransactionType { get; set; } = CommandType.CustomerPayBillOnline;
  public string? Amount { get; set; }
  public string? PartyA { get; set; }
  public string? PartyB { get; set; }
  public string? PhoneNumber { get; set; }
  public string? CallBackURL { get; set; }
  public string? AccountReference { get; set; }
  public string? TransactionDesc { get; set; }
}

public class LipaNaMpesaResponse
{
        public string? MerchantRequestID { get; set; }
        public string? CheckoutRequestID { get; set; }
        public string? ResponseCode { get; set; }
        public string? ResponseDescription { get; set; }
        public string? CustomerMessage { get; set; }
}

public static class LipaNaMpesaOnline {

  public static async Task<LipaNaMpesaResponse> LipaNaMpesaOnlineAsync(this IMpesa mpesaclient, LipaNaMpesaRequest lipanampesaonlinerequest){

    
    var payload = JsonSerializer.Serialize(lipanampesaonlinerequest);
    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
    var response = await mpesaclient.Client.PostAsync(MpesaRoute.LipaNa_MpesaOnline, c);
    //TODO throw exception
    if(response is null) throw new Exception("Lipa Na Mpesa: Unsucceful");
    return await JsonSerializer.DeserializeAsync<LipaNaMpesaResponse>(response.Content.ReadAsStreamAsync().Result);
  }
}

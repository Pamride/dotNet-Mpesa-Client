using System.Text;
using System.Text.Json;
using Mpesa.lib.Routes;
using Mpesa.lib.Services;

namespace Mpesa.Features;

public class LipaNaMpesaQueryRequest
{
  public string? BusinessShortCode { get; set; }
  public string? Password {get; set;}
  public string? Timestamp { get; set; } 
  public string? CheckoutRequestID {get; set;}
}


public class LipaNaMpesaOnlineStatusResponse: IResponse
    {
        public string? ResponseCode { get; set; }
        public string? ResponseDescription { get; set; }
        public string? MerchantRequestID { get; set; }
        public string? CheckoutRequestID { get; set; }
        public string? ResultCode { get; set; }
        public string? ResultDesc { get; set; }
    }



public static class LipaNaMpesaOnlineStatus {

  public static async Task<LipaNaMpesaOnlineStatusResponse> LipaNaMpesaOnlineStatusAsync(this IMpesa mpesaclient,   LipaNaMpesaQueryRequest lipanampesaonlinestatusrequest){
    var payload = JsonSerializer.Serialize(lipanampesaonlinestatusrequest);
    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
    var response = await mpesaclient.Client.PostAsync(MpesaRoute.LipaNa_MpesaOnlineStatus, c);
    return await JsonSerializer.DeserializeAsync<LipaNaMpesaOnlineStatusResponse>(await response.Content.ReadAsStreamAsync());
}
}


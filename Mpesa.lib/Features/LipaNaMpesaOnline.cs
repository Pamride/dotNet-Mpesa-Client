using Mpesa.lib.Enums;
using System.Text;
using System.Text.Json;
using Mpesa.lib;
using Mpesa.lib.Routes;
using Mpesa.lib.Services;
using System.Text.Json.Serialization;
using System.Net;

namespace Mpesa.Features;

public class LipaNaMpesaRequest
{
  public string? BusinessShortCode { get; set; }
  public string? Password { get; set; }
  public string? Timestamp { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public CommandType TransactionType { get; set; } = CommandType.CustomerPayBillOnline;
  public string? Amount { get; set; }
  public string? PartyA { get; set; }
  public string? PartyB { get; set; }
  public string? PhoneNumber { get; set; }
  public string? CallBackURL { get; set; }
  public string? AccountReference { get; set; }
  public string? TransactionDesc { get; set; } = "Pay for you car ride fare";
}

public interface IResponse{

}

public class LipaNaMpesaResponse: IResponse
{
        public string? MerchantRequestID { get; set; }
        public string? CheckoutRequestID { get; set; }
        public string? ResponseCode { get; set; }
        public string? ResponseDescription { get; set; }
        public string? CustomerMessage { get; set; }
}

public class Error :  IResponse
{
        public string? requestId { get; set; }
        public string? errorCode { get; set; }
        public string? errorMessage { get; set; }
}

public static class LipaNaMpesaOnline {

  public static async Task<IResponse> LipaNaMpesaOnlineAsync(this IMpesa mpesaclient, LipaNaMpesaRequest lipanampesaonlinerequest){

    try {
    var payload = JsonSerializer.Serialize(lipanampesaonlinerequest);
    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
    var response = await mpesaclient.Client.PostAsync(MpesaRoute.LipaNa_MpesaOnline, c);
    string contentasstream = await response.Content.ReadAsStringAsync();
    Console.WriteLine(contentasstream);

    if(response.StatusCode ==  HttpStatusCode.InternalServerError || response.StatusCode ==  HttpStatusCode.BadRequest){
         return JsonSerializer.Deserialize<Error>(contentasstream);
    }else if(response.StatusCode ==  HttpStatusCode.OK ){
         return JsonSerializer.Deserialize<LipaNaMpesaResponse>(contentasstream);
    }
   }catch(Exception ex) {
        throw new Exception(ex.Message);
   }
        throw new Exception("Try new stuff");
  }
}

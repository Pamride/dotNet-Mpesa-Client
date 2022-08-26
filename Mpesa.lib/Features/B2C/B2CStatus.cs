using System.Text;
using System.Text.Json;
using Mpesa.Lib.Routes;
using Mpesa.Lib.Services;

namespace Mpesa.Features;

public class B2CStatusRequest
{
    public string? BusinessShortCode { get; set; }
    public string? Password { get; set; }
    public string? Timestamp { get; set; }
    public string? CheckoutRequestID { get; set; }
}

public class B2CStatusResponse : IResponse
{ 
    public string? ResultCode { get; set; }
    public string? ResultDesc { get; set; }
}

public static class B2CStatus
{
    public static async Task<B2CStatusResponse> B2CStatusAsync(this IMpesa mpesaclient, B2CStatusRequest b2CStatusRequest)
    {
        var payload = JsonSerializer.Serialize(b2CStatusRequest);
        HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
        var response = await mpesaclient.Client.PostAsync(MpesaRoute.B2CUriStatus, c);
        B2CStatusResponse? responseJson = await JsonSerializer.DeserializeAsync<B2CStatusResponse>(await response.Content.ReadAsStreamAsync());
        return responseJson!;
    }
}


using Mpesa.Lib.Enums;
using System.Text;
using System.Text.Json;
using Mpesa.Lib.Routes;
using Mpesa.Lib.Services;
using System.Text.Json.Serialization;

namespace Mpesa.Features;

public class B2CRequest
{
    public string? InitiatorName { get; set; }
    public string? SecurityCredential { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CommandType? CommandId { get; set; } = CommandType.BusinessPayment;
    public string? Amount { get; set; }
    public string? PartyA { get; set; }
    public string? PartyB { get; set; }
    public string? Remarks { get; set; }
    public string? QueueTimeOutURL { get; set; }
    public string? ResultURL { get; set; }
    public string? Occassion { get; set; }
}

public class B2CResponse : IResponse
{
    public string? ConversationID { get; set; }
    public string? OriginatorConversationID { get; set; }
    public string? ResponseCode { get; set; }
    public string? ResponseDescription { get; set; }
}

public static class B2C
{
    public static async Task<IResponse> B2CAsync(this IMpesa mpesaClient, B2CRequest b2CRequest)
    {
        var payload = JsonSerializer.Serialize(b2CRequest);
        HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await mpesaClient.Client.PostAsync(MpesaRoute.B2CUri, content);
        Stream? responseContent = await responseMessage.Content.ReadAsStreamAsync();
        B2CResponse? responseJson = await JsonSerializer.DeserializeAsync<B2CResponse>(responseContent);
        return responseJson!;
    }
}

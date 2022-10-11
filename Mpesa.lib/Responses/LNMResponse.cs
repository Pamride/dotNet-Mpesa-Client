
namespace Mpesa.Lib;

// Root myDeserializedClass = JsonConvert.DeserializeObject<LNMOnlineResponse>(myJsonResponse);
public class Body
{
    public StkCallback stkCallback { get; set; }
}

public class CallbackMetadata
{
    public List<Item> Item { get; set; }
}

public class Item
{
    public string Name { get; set; }
    public object Value { get; set; }
}

public class LNMOnlineResponse
{
    public Body Body { get; set; }
}

public class StkCallback
{
    public string MerchantRequestID { get; set; }
    public string CheckoutRequestID { get; set; }
    public int ResultCode { get; set; }
    public string ResultDesc { get; set; }
    public CallbackMetadata CallbackMetadata { get; set; }
}


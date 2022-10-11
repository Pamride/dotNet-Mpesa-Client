namespace Mpesa.Features;

public interface IResponse
{

}
 
public class BaseError : IResponse
{
    public string? requestId { get; set; }
    public string? errorCode { get; set; }
    public string? errorMessage { get; set; }
}
using mpesa.lib.settings;
using Mpesa;
using Mpesa.lib.Services;
using Mpesa.lib.Enums;
using Mpesa.Factory;
using Mpesa.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = builder.Configuration.GetSection("MpesaConfig").Get<Config>();

builder.Services.ConfigureMpesa(settings);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapPost("/lipaNaMpesaOnline", async (IMpesa mpesa, string phonenumber, string amount, string url) =>
{
    var lipanampesarequest = factory.CreateLipaNaMpesaRequest(settings);
    lipanampesarequest.Amount = amount;
    lipanampesarequest.CallBackURL = url;
    lipanampesarequest.PartyA = phonenumber;
    lipanampesarequest.PhoneNumber = phonenumber;
    var response = await mpesa.LipaNaMpesaOnlineAsync(lipanampesarequest);
    return Results.Ok(response);
});
app.MapPost("/lipaNaMpesaOnlineStatus", async (IMpesa mpesa, string CheckoutRequestId) =>
{
    var lipanampesastatusrequest = factory.CreateLipaNaMpesaStatusRequest(settings);
    lipanampesastatusrequest.CheckoutRequestID = CheckoutRequestId;
    var response = await mpesa.LipaNaMpesaOnlineStatusAsync(lipanampesastatusrequest);
    return Results.Ok(response);
});
app.MapPost("/unsuccessfulCallback", () => "Not Successful");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

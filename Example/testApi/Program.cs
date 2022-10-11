using Mpesa.Lib.Settings;
using Mpesa;
using Mpesa.Lib.Services;
using Mpesa.Lib.Enums;
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

// example for LipaNaMpesaOnline
app.MapPost("/lipaNaMpesaOnline", async (IMpesa mpesa, string phonenumber, string amount, string  callBackURL) =>
{
    var lipanampesarequest = factory.CreateLipaNaMpesaRequest(settings);
    lipanampesarequest.Amount = amount;
    lipanampesarequest.CallBackURL =  callBackURL;
    lipanampesarequest.PartyA = phonenumber;
    lipanampesarequest.PhoneNumber = phonenumber;
    var response = await mpesa.LipaNaMpesaOnlineAsync(lipanampesarequest);
    return Results.Ok(response);
});

// example for LipaNaMpesaOnlineStatus
app.MapPost("/lipaNaMpesaOnlineStatus", async (IMpesa mpesa, string CheckoutRequestId) =>
{
    var lipanampesastatusrequest = factory.CreateLipaNaMpesaStatusRequest(settings);
    lipanampesastatusrequest.CheckoutRequestID = CheckoutRequestId;
    var response = await mpesa.LipaNaMpesaOnlineStatusAsync(lipanampesastatusrequest);
    return Results.Ok(response);
});

// example for B2CAsync
app.MapPost("/b2C", async (IMpesa mpesa, string phonenumber, string amount, string callBackURL, string occassion, string remarks) =>
{
     var b2CRequest = factory.CreateB2CRequest(settings);
     b2CRequest.Amount = amount; 
     b2CRequest.ResultURL = callBackURL;
     b2CRequest.PartyA = phonenumber;
     b2CRequest.Remarks = remarks;
     b2CRequest.Occassion = occassion;
     var response =  await mpesa.B2CAsync(b2CRequest);
     return Results.Ok(response);
});

// example for B2CStatus
app.MapPost("/b2cStatus", async (IMpesa mpesa, string CheckoutRequestId) =>
{
    var  b2CStatusRequest = factory.CreateB2CStatusRequest(settings);
    b2CStatusRequest.CheckoutRequestID = CheckoutRequestId;
    var response = await mpesa.B2CStatusAsync(b2CStatusRequest);
    return Results.Ok(response);
});

app.MapPost("/unsuccessfulCallback", () => "Not Successful");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

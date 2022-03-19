using mpesa.lib.settings;
using Mpesa;
using Mpesa.lib.Services;
using Mpesa.lib.Enums;
using Mpesa.Factory;
using Mpesa.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var settings = builder.Configuration.GetSection("MpesaConfig").Get<Config>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureMpesa(settings);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/paymentrequest" , async() => {
        Enum.TryParse(settings.Env, out Env enviroment);
         IMpesa client = factory.CreateMpesaClient(settings, enviroment);
         
         var lipanampesarequest = factory.CreateLipaNaMpesaRequest(settings);
         lipanampesarequest.Amount = "10";
         lipanampesarequest.CallBackURL = "nope ";
         lipanampesarequest.PartyA = "0758874026";
         lipanampesarequest.PhoneNumber = "0758874026";

         await client.LipaNaMpesaOnlineAsync(lipanampesarequest); 
    });
app.MapPost("/successCallback", () => "succuss");
app.MapPost("/unsuccessfulCallback", () => "Not Successful");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using mpesa.lib.settings;
using Mpesa;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var settings = builder.Configuration.GetSection("MpesaConfig").Get<Config>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureMpesa(settings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

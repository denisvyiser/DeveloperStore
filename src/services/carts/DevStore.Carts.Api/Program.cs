using DevStore.Carts.Api.Configurations;
using DevStore.Core.Authentication.Config;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiConfiguration(builder.Configuration);

var cert = builder.Configuration["CERTIFICATEKEY"];
var signingConfig = new SigningConfig(cert);

builder.Services.AddSingleton(signingConfig);

var tokenConfig = builder.Configuration.GetSection("TokenConfig").Get<TokenConfig>();

builder.Services.AddSingleton(tokenConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiConfiguration(builder.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
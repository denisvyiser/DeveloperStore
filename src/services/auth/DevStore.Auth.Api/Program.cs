using DevStore.Auth.Api.Configurations;
using DevStore.Core.Authentication.Config;
using Microsoft.Extensions.Configuration;
using ProtoBuf.Grpc.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var cert = builder.Configuration["CERTIFICATEKEY"];
var signingConfig = new SigningConfig(cert);

builder.Services.AddSingleton(signingConfig);

var tokenConfig = builder.Configuration.GetSection("TokenConfig").Get<TokenConfig>();

builder.Services.AddSingleton(tokenConfig);


builder.Services.AddApiConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiConfiguration(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

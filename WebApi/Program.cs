using Application;
using Application.Service.Implement;
using Application.Service;
using Azure.Storage.Blobs;
using WebRecruitment.Infrastructures;
using WebRecruitment.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json", false, true)
    .Build();

// appConfiguration
var appConfiguration = configuration.Get<AppConfiguration>();

builder.Services.InfrastructuresConfiguration(appConfiguration.DatabaseConnection, configuration, appConfiguration.AzureBlobStorage);
builder.Services.WebApiConfiguration(appConfiguration.JWTSecretKey);

builder.Services.AddSingleton(appConfiguration);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
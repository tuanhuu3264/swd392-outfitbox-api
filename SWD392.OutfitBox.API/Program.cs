using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.IO.Pipelines.Testing;
using SWD392.OutfitBox.API.CollectionRegisters;
using SWD392.OutfitBox.API.Configurations.Authorizations;
using SWD392.OutfitBox.API.Configurations.Databases;
using SWD392.OutfitBox.API.Configurations.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddJwtAuthorization(builder.Configuration);
builder.Services.AddSQLServerDatabase(builder.Configuration);
builder.Services.AddRedis(builder.Configuration);
builder.Services.RegisterService();
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("./outfit4rent-c7575-firebase-adminsdk-i1m0b-65ecec1826.json"),
    ProjectId = "outfit4rent-c7575"
    // Add more options as needed
});
var app = builder.Build();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
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

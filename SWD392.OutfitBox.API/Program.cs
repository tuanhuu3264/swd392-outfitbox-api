using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SWD392.OutfitBox.API.CollectionRegisters;
using SWD392.OutfitBox.API.Configurations.Authorizations;
using SWD392.OutfitBox.API.Configurations.Databases;
using SWD392.OutfitBox.API.Configurations.Firebase;
using SWD392.OutfitBox.API.Configurations.Swagger;
using SWD392.OutfitBox.BackgroundWorker.NotReturnedCustomerTask;
using SWD392.OutfitBox.BackgroundWorker.RedisTask;
using SWD392.OutfitBox.BackgroundWorker.ReturnMoneyTask;
using SWD392.OutfitBox.BackgroundWorker.StatusOrderTask;
using SWD392.OutfitBox.DataLayer.Databases.Redis.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Management;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("./appsettings.Development.json")
                     .AddJsonFile("./firebase-storage-key.json")
                     .AddJsonFile("./appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddJwtAuthorization(builder.Configuration);
builder.Services.AddDatabaseSQLServer(builder.Configuration);
builder.Services.AddRedis(builder.Configuration);
builder.Services.RegisterService();
builder.Configuration.CreateFirebaseApp();
// Add hosted service
builder.Services.AddSingleton<UpdateRedisData>();
builder.Services.AddHostedService<StatusOrderHost>();
builder.Services.AddHostedService<NotificationUserBackgroundService>();
builder.Services.AddHostedService<ReturnMoneyBackgroundService>();
builder.Services.AddHostedService<NotReturnedCustomerTask>();
builder.Services.AddHostedService<SetDataRedis>();

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

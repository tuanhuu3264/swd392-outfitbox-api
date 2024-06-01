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
builder.Services.RegisterService();

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

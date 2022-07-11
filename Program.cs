using MongoExample.Services;
using WebAPI.Interfaces;
using WebAPI.Repos;

var builder = WebApplication.CreateBuilder(args);
string corsDev = "CorsDev";
// Add services to the container.
builder.Services.AddCors(policies =>
{
    policies.AddPolicy(name: corsDev,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDBSettingsModel>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IConfigData, ConfigData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(corsDev);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TP_Complot_Rest.Common;
using TP_Complot_Rest.Managers;
using TP_Complot_Rest.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<SourceSettings>(builder.Configuration.GetSection("SourceSettings"));
builder.Services.AddScoped<IComplotManager, WikipediaManager>();
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
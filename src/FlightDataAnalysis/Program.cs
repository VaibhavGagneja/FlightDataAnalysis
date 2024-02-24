using FlightDataAnalysis.Infrastructure.Mvc;
using FlightDataAnalysis.Infrastructure.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterMvc();
builder.Services.RegisterSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

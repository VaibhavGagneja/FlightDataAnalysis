var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterMvc();
builder.Services.RegisterSwagger();
builder.Services.RegisterExceptionHandler();
builder.Services.RegisterAutoMapper();

var app = builder.Build();

app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

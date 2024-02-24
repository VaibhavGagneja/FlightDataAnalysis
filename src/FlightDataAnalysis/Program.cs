var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterOptions(builder.Configuration);
builder.Services.RegisterMvc();
builder.Services.RegisterSwagger();
builder.Services.RegisterExceptionHandler();
builder.Services.RegisterAutoMapper();
builder.Services.RegisterBusiness();
builder.Services.RegisterData();
builder.Services.RegisterInitializer();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var initializer = scope.ServiceProvider.GetRequiredService<IServiceInitializer>();
initializer.Initialize();

app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

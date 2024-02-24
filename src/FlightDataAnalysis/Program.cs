var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterMvc();
builder.Services.RegisterSwagger();
builder.Services.RegisterExceptionHandler();

var app = builder.Build();

app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

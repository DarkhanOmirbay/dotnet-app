using MyApi.Interfaces;
using MyApi.Services;
using Microsoft.OpenApi.Models;
using DotNetEnv;

// .env
DotNetEnv.Env.Load();
string? originsEnv = Environment.GetEnvironmentVariable("ORIGINS");
string[] allowedOrigins = originsEnv?.Split(",") ?? Array.Empty<string>();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApi", Version = "v1" });
});
builder.Services.AddSingleton<ITodoService, TodoService>();

// lowercase urls
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
// add cors
builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins(allowedOrigins).AllowAnyHeader()
                  .AllowAnyMethod();
            }
        );
    }
);

Console.WriteLine("ALLOWED ORIGINS:");
foreach (var o in allowedOrigins)
{
    Console.WriteLine(o);
}

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// any origins urls
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

using Howdy;
using Howdy.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run();

builder.Services.AddCors(options =>
options.AddDefaultPolicy(builder =>
{
    builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
}));

builder.Services.AddSingleton<IDictionary<string, UserConnection>>(opts => new Dictionary<string, UserConnection>());

builder.Services.AddSignalR();
app.UseCors();
app.UseRouting();
app.MapHub<ChatHub>("/chat"); 

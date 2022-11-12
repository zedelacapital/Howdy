using Howdy.Hubs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run();



builder.Services.AddSignalR();

builder.Services.AddCors(options =>
options.AddDefaultPolicy(builder =>
{
    builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
}));

app.UseCors("http://localhost:3000");
app.UseRouting();
app.MapHub<ChatHub>("/chat");
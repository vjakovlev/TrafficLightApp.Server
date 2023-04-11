using TrafficLightApp.HubConfig;
using TrafficLightApp.Repositories.Abstraction;
using TrafficLightApp.Repositories.Implementation;
using TrafficLightApp.Services.Abstraction;
using TrafficLightApp.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));

builder.Services.AddSignalR();

builder.Services.AddTransient<ITrafficLightService, TrafficLightService>();
builder.Services.AddTransient<ITrafficLightRepository, TrafficLightRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<TrafficLightHub>("/trafficlight");
app.Run();

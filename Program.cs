using Microsoft.AspNetCore.Mvc;
using PubSubService.Events;
using PubSubService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<EventQueue>();
builder.Services.AddSingleton<PublishingService>();
builder.Services.AddSingleton<SubscribingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/publish", (string message) =>
{
    var publishingService = app.Services.GetRequiredService<PublishingService>();
    publishingService.Publish(message);
});

app.MapGet("/readmessage",  () =>
{
    var subscribingService = app.Services.GetRequiredService<SubscribingService>();
    return subscribingService.Receive();
});

app.Run();


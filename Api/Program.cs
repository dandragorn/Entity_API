using App;
using App.Handlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var appServiceHost = new AppServiceHost();
await appServiceHost.Start(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Entity.WebApi");
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
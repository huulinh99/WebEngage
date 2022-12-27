using Microsoft.EntityFrameworkCore;
using WebEngage.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("myClient", client =>
{
    client.BaseAddress = new Uri("https://api.webengage.com/v1/accounts/");
});

builder.Services.AddDbContext<WebEngageContext>(x => x.UseSqlServer("Server=LINHNGUYEN;Database=LinhTest;Trusted_Connection=True;TrustServerCertificate=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

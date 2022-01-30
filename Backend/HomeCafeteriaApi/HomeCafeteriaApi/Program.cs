using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HomeCafeteriaApi.Data;
var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<HomeCafeteriaApiContext>(options =>
        options.UseInMemoryDatabase("HomeCafeteriaApiContext"));

if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<HomeCafeteriaApiContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Production")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(b =>
    {
        b.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var ctx = services.GetRequiredService<HomeCafeteriaApiContext>();
    ctx.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

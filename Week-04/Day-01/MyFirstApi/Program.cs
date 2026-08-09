using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyFirstApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddSingleton<
    MyFirstApi.Services.IMessageService,
    MyFirstApi.Services.MessageService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<MyFirstApi.Middleware.RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

var items = new List<string>
{
    "Laptop",
    "Mouse",
    "Keyboard"
};

app.MapGet("/minimal/items", () =>
{
    return Results.Ok(items);
});

app.MapGet("/minimal/items/{id}", (int id) =>
{
    if (id < 1 || id > items.Count)
    {
        return Results.NotFound("Item not found");
    }

    return Results.Ok(items[id - 1]);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
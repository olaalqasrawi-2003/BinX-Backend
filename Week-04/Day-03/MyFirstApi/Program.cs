using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyFirstApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"], 
        ValidAudience = builder.Configuration["Jwt:Audience"],
        
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequiredAdminEmail", policy => 
    policy.RequireClaim(ClaimTypes.Email, "admin@gmail.com"));
});

builder.Services.AddSingleton<
    MyFirstApi.Services.IMessageService,
    MyFirstApi.Services.MessageService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if(!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }

    if(!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var user = await userManager.FindByEmailAsync("ola@gmail.com");
    if(user != null && !await userManager.IsInRoleAsync(user, "User")){
        await userManager.AddToRoleAsync(user, "User");
    }

    var admin = await userManager.FindByEmailAsync("admin@gmail.com");
    if(admin != null && !await userManager.IsInRoleAsync(admin, "Admin")){
        await userManager.AddToRoleAsync(admin, "Admin");
    }
}

app.UseMiddleware<MyFirstApi.Middleware.RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

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
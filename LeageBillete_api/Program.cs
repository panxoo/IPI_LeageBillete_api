using LeageBillete_api.Data;
using LeageBillete_api.Interfaces;
using LeageBillete_api.Methodes;
using LeageBillete_api.Model.Setting;
using LeageBillete_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



string stringConnexion = builder.Configuration.GetConnectionString("connexion_mysql");


builder.Services.Configure<TokensSettings>(builder.Configuration.GetSection("Tokens"));

builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseMySql(stringConnexion, MySqlServerVersion.AutoDetect(stringConnexion)));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    //cfg.Audience = builder.Configuration["Tokens:Issuer"];
                    //cfg.Authority = builder.Configuration["Tokens:Issuer"];
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Tokens:Issuer"],
                        ValidAudience = builder.Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]))
                    };
                    cfg.SaveToken = true;
                });



builder.Services.AddCookiePolicy(options =>
{
    // options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
    options.Secure = CookieSecurePolicy.Always;
    options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;


});


builder.Services.AddIdentityCore<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
 .AddDefaultTokenProviders();

builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<IBilletAdmin, BilletAdmin>();
builder.Services.AddScoped<IAuthentification, Authentification>();
builder.Services.AddScoped<IReserveTicket, ReserveTicket>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Ejecutar inicialización
using (var scope = app.Services.CreateScope())
{
    var authentification = scope.ServiceProvider.GetRequiredService<IAuthentification>();
    await authentification.DataIni();
}

app.UseCors(builder =>

    builder.SetIsOriginAllowed(origin => true)
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
);


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
using WebShop.Data;
using WebShop.Models.Dbo;
using WebShop.Services.Implementation;
using WebShop.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebShop.Models.Dto;
using System.IdentityModel.Tokens.Jwt;
using WebShop.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//options.SignIn.RequireConfirmedAccount = true,

{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.ClaimsIdentity.UserIdClaimType = JwtRegisteredClaimNames.Jti;

})

    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddOpenApiDocument();


builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy.AllowAll, builder => builder.WithOrigins("http://localhost:7289")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true));
});

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddControllersWithViews();

builder.Services.Configure<AppConfig>(builder.Configuration);
builder.Services.AddSingleton<IIdentityService, IdentityService>();
builder.Services.AddScoped<IUserSevice, UserSevice>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, QueueProcessor>();


string tokenIssuerAndAudience = builder.Configuration["AppUrl"];
string tokenKey = builder.Configuration["Identity:Key"];
builder.Services.AddAuthentication().AddJwtBearer(options =>
{

    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = tokenIssuerAndAudience,
        ValidAudience = tokenIssuerAndAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

#region Swagger
app.UseOpenApi(); // serve OpenAPI/Swagger documents
app.UseSwaggerUi3(); // serve Swagger UI
app.UseReDoc();
#endregion

app.UseRouting();
app.UseCors(CorsPolicy.AllowAll);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Services.GetService<IIdentityService>();

app.Run();

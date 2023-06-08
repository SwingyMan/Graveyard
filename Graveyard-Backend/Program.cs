using System.Text;
using Graveyard_Backend.IRepositories;
using Graveyard_Backend.IServices;
using Graveyard_Backend.Models;
using Graveyard_Backend.Repositories;
using Graveyard_Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Graveyard_Backend", Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
    c.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ContextModel>();
using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("./logs.txt")
    .Enrich.WithClientIp()
    .Enrich.WithClientAgent()
    .CreateLogger();
builder.Host.UseSerilog(log);
builder.Services.AddHttpClient();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBurriedService, BurriedService>();
builder.Services.AddScoped<IBurriedRepository, BurriedRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IGraveBurriedRepository, GraveBurriedRepository>();
builder.Services.AddScoped<IGraveBurriedService, GraveBurriedService>();
builder.Services.AddScoped<IGravediggerRepository, GravediggerRepository>();
builder.Services.AddScoped<IGravediggerService, GravediggerService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IPurchaseHistoryRepository, PurchaseHistoryRepository>();
builder.Services.AddScoped<IPurchaseHistoryService, PurchaseHistoryService>();
builder.Services.AddSingleton<ILogger>(log);
log.Information("Done setting up server!");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "localhost:7079",
            ValidAudience = "localhost:7079",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    "48E55B3CBC709E10CF33C343714AA2386D7FF9EB9A983E6FD14CADF6982A62EC85D801B1876EB4D93F02725131CD763C528E01E4F427316574AA9BA01E4BDBF8431172BE3C29E17156BF586584A56F105E64F2F62ADC480A")
            )
        };
    });
builder.Services.AddAuthorization(options =>
{
    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
        JwtBearerDefaults.AuthenticationScheme);
    defaultAuthorizationPolicyBuilder =
        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();
app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
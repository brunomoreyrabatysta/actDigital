using APIMsFinanceiro;
using APIMsFinanceiro.Data;
using APIMsFinanceiro.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using APIMsFinanceiro.API.Models.Repositories;
using APIMsFinanceiro.API.Infra.Repositories;
using APIMsFinanceiro.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureService(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
LoadConfiguration(app);

if (app.Environment.IsProduction())
    app.UseHttpsRedirection();
else if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.UseResponseCompression();

app.Run();




void LoadConfiguration(WebApplication _app)
{
    Configuration.JwtKey = _app.Configuration.GetValue<string>("JwtKey");
    Configuration.ClientId = _app.Configuration.GetValue<string>("ClientId");
    Configuration.ClientSecret = _app.Configuration.GetValue<string>("ClientSecret");
    Configuration.ApiKeyName = _app.Configuration.GetValue<string>("ApiKeyName");
    Configuration.ApiKey = _app.Configuration.GetValue<string>("ApiKey");
}

void ConfigureAuthentication(WebApplicationBuilder _builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

    _builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}


void ConfigureMvc(WebApplicationBuilder _builder)
{
    _builder.Services.AddMemoryCache();
    _builder.Services.AddResponseCompression(options =>
    {
        // options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>();
        // options.Providers.Add<CustomCompressionProvider>();
    });
    _builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });
    _builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    });
}

void ConfigureService(WebApplicationBuilder _builder)
{
    var connectionString = _builder.Configuration.GetConnectionString("DefaultConnection");

    _builder.Services.AddSqlConnection(connectionString);
    _builder.Services.AddServices();
    _builder.Services.AddRepositories();
}
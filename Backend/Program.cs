using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(Settings.JwtSecret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

string? connection = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddSingleton(new DbConnectionFactory(conn: connection));
builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<ParceriaService>();
builder.Services.AddSingleton<ParceriaRepository>();
builder.Services.AddSingleton<AnexoRepository>();
builder.Services.AddSingleton<AnexoService>();
builder.Services.AddSingleton<LoginService>(); 

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PROFESSOR", policy => policy.RequireRole("PROFESSOR"));
    options.AddPolicy("COMITE", policy => policy.RequireRole("COMITE"));
    options.AddPolicy("ADMINISTRADOR", policy => policy.RequireRole("ADMINISTRADOR"));
});

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

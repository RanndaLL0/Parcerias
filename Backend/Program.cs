var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("PostgresConnection");
builder.Services.AddSingleton(new DbConnectionFactory(conn: connection));
builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<ParceriaService>();
builder.Services.AddSingleton<ParceriaRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

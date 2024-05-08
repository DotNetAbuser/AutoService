var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var kestrelSection = configuration.GetSection("Kestrel");
    serverOptions.Configure(kestrelSection);
}).UseKestrel();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(configuration);

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddJwtAuthentication(configuration);
builder.Services.AddSwagger();

var app = builder.Build();

#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
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

builder.Services.AddCors();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

#if DEBUG
app.AddSwagger();
#else
app.UseForwardedHeaders();
#endif

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.MapControllers();

app.Run();
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddServices();
builder.Services.AddManagers();
builder.Services.AddAndConfigureHttpClientFactory();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthenticationStateProvider>());

await builder.Build().RunAsync();
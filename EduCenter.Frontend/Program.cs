using System.Text.RegularExpressions;
using EduCenter.Frontend.Clients;
using EduCenter.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

string baseAddress =
    builder.Configuration["BackendUrl"]
    ?? throw new NullReferenceException("BaseApiAddress is not implementend");

// Add services to the container.
builder
    .Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient<UserClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient<RoleClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient<CenterClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});
builder.Services.AddHttpClient<ScienceClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient<TeacherClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient<StudentClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient<GroupClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

builder.Services.AddHttpClient<StudentPaymentClient>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

// .AddInteractiveWebAssemblyRenderMode();

app.Run();

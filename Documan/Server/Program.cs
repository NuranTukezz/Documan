using Documan.Server.Services;
using Blazored.Modal;
using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddSingleton<MenuOperationsService>(new MenuOperationsService());
builder.Services.AddSingleton<LoginService>(new LoginService());
builder.Services.AddSingleton<MenuService>(new MenuService());
builder.Services.AddSingleton<AuthorizationService>(new AuthorizationService());
builder.Services.AddSingleton<DocumentService>(new DocumentService());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

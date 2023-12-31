using HogWildWebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using MudBlazor.Services;   // for AddMudServices() extension method

using HogWildSystem;                    // for AddBackendDependencies extension method
using Microsoft.EntityFrameworkCore;    // for UseSqlServer extension extension method

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//  :given (This is code that is provided when we create our application)
//  supplied database connection due to the fact that we created this
//      web app to use Individual accounts

//  :added
//  code retrieves the HogWild connection string
var connectionStringHogWild = builder.Configuration.GetConnectionString("OLTP-DMIT2018");

//  added:
//  Code the logic to add our class library services to IServiceCollection
//  One could do the registration code here in Program.cs
//  HOWEVER, every time a service class is added, you would be changing this file
//  The implementation of the DBContent and AddTransient(...) code in this example
//        will be done in an extension method to IServiceCollection
//  The extension method will be code inside the HogWildSystem class library
//  The extension method will have a paramater: options.UseSqlServer()
builder.Services.AddBackendDependencies(options =>
    options.UseSqlServer(connectionStringHogWild));


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using BlazorWhyUseDbContextFactory.Components;
using BlazorWhyUseDbContextFactory.Components.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ToDoService>();

var configuration = builder.Configuration;
// On Azure (after publish) the Default connection string in Azure overrides the appsettings.json
var connectionString = configuration.GetConnectionString("Default");
// You should use context factory!! We DO NOT NEED BOTH OF THESE! Both are coded to simplify showing how one works and one fails!
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString)); // Not using db context factory
builder.Services.AddDbContextFactory<AppDbContext>(item => item.UseSqlServer(connectionString));// Using db context factory

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

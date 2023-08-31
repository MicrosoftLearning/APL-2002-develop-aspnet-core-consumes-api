using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add IHttpClientFactory to the container and sets the name of the factory
// to "FruitAPI", and the also sets the base address used in calls
builder.Services.AddHttpClient("FruitAPI", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:5050/fruitlist/");
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

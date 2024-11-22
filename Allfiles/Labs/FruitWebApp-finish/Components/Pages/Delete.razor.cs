using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using FruitWebApp.Models;
using System.Text.Json;
using System.Text;
using System;

namespace FruitWebApp.Components.Pages;

public partial class Delete : ComponentBase
{
    // IHttpClientFactory set using dependency injection 
    [Inject]
    public required IHttpClientFactory HttpClientFactory { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    // Add the data model and bind the form data to the page model properties

    [SupplyParameterFromForm]
    private FruitModel? _fruitList { get; set; }

    [Parameter]
    public int? delId { get; set; }

    // Create instance of data model when page is initialized
    protected override async void OnInitialized()
    {
        _fruitList ??= new();

        // Create the HTTP client using the FruitAPI named factory
        var httpClient = HttpClientFactory.CreateClient("FruitAPI");

        Console.WriteLine("Parameter: " + delId);

        // Retrieve record information
        using HttpResponseMessage response = await httpClient.GetAsync(delId.ToString());

        if (response.IsSuccessStatusCode)
        {
            // Deserialize the response to populate the form
            using var contentStream = await response.Content.ReadAsStreamAsync();
            _fruitList = await JsonSerializer.DeserializeAsync<FruitModel>(contentStream);
        }
        else
        {
            Console.WriteLine("Failed to retrieve fruit");
        }
    }

    // Get the Id of the record to delete from the query string

    private async Task Submit()
    {
        // Something
    }
}
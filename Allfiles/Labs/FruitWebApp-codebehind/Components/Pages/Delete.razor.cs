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

    // NavigationManager set using dependency injection
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    // Add the data model and bind the form data to the page model properties
    [SupplyParameterFromForm]
    private FruitModel? _fruitList { get; set; }

    // Add the parameter to the page
    [Parameter]
    public int? Id { get; set; }

    // Initialize the fruit list
    protected override void OnInitialized() => _fruitList ??= new();

    //  Retrieve the data to populate the form for deletion
    protected override async Task OnInitializedAsync()
    {
        // Create the HTTP client using the FruitAPI named factory
        var httpClient = HttpClientFactory.CreateClient("FruitAPI");

        // Retrieve record information
        using HttpResponseMessage response = await httpClient.GetAsync($"/fruits/{Id}");

        if (response.IsSuccessStatusCode)
        {
            // Deserialize the response to populate the form
            using var contentStream = await response.Content.ReadAsStreamAsync();
            _fruitList = await JsonSerializer.DeserializeAsync<FruitModel>(contentStream);
        }
        else
        {
            Console.WriteLine("Failed to retrieve fruit. Status code: {response.StatusCode}");
        }
    }

    // Begin DELETE operation code
    private async Task Submit()
    {
        // Create the HTTP client using the FruitAPI named factory
        var httpClient = HttpClientFactory.CreateClient("FruitAPI");

        // Execute the DELETE request and store the response
        using HttpResponseMessage response = await httpClient.DeleteAsync("/fruits/" + Id.ToString());

        // Return to the home page 
        if (response.IsSuccessStatusCode)
        {
            NavigationManager?.NavigateTo("/");
        }
        else
        {
            Console.WriteLine("Failed to delete fruit. Status code: {response.StatusCode}");
        }
    }
    // End DELETE operation code
}
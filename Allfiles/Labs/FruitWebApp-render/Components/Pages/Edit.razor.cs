using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using FruitWebApp.Models;
using System.Text.Json;
using System.Text;
using System;


namespace FruitWebApp.Components.Pages;

public partial class Edit : ComponentBase
{
    // IHttpClientFactory set using dependency injection 
    [Inject]
    public required IHttpClientFactory HttpClientFactory { get; set; }

    // NavigationManager set using dependency injection
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    // Add the data model and bind the form data to it
    [SupplyParameterFromForm]
    private FruitModel? _fruitList { get; set; }

    // Get the Id of the record to edit from the query string
    [Parameter]
    public int? Id { get; set; }

    // Create instance of data model when page is initialized
    protected override void OnInitialized() => _fruitList ??= new FruitModel();

    // Retrieve the data to populate the form for editing
    protected override async Task OnInitializedAsync()
    {
        // Create the HTTP client using the FruitAPI named factory
        var httpClient = HttpClientFactory.CreateClient("FruitAPI");

        // Retrieve record information
        using HttpResponseMessage response = await httpClient.GetAsync("/fruits/" + Id.ToString());

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

    // Begin PUT operation code
    private async Task Submit()
    {
        // Create the HTTP client using the FruitAPI named factory
        var httpClient = HttpClientFactory.CreateClient("FruitAPI");

        // Store the updated data in a JSON object
        var jsonContent = new StringContent(JsonSerializer.Serialize(_fruitList), 
            Encoding.UTF8, "application/json");

        // Execute the PUT request
        using HttpResponseMessage response = await httpClient.PutAsync($"/fruits/{Id}", jsonContent);

        // If the response is successful, navigate back to the home page 
        if (response.IsSuccessStatusCode)
        {
            NavigationManager?.NavigateTo("/");
        }
        else
        {
            Console.WriteLine("Failed to update fruit with edits. Status code: {response.StatusCode}");
        }
    }
    // End PUT operation code
}
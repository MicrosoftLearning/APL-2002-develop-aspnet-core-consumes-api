using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using FruitWebApp.Models;
using System.Text.Json;
using System.Text;

namespace FruitWebApp.Components.Pages;

public partial class Add : ComponentBase
{
    // IHttpClientFactory set using dependency injection 
    [Inject]
    public required IHttpClientFactory HttpClientFactory { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    // Add the data model and bind the form data to the page model properties
    // Enumerable since an array is expected as a response

    [SupplyParameterFromForm]
    private FruitModel? _fruitList { get; set; }

    protected override void OnInitialized() => _fruitList ??= new();

    // Begin POST operation code
    private async Task Submit()
    {
        // Serialize the information to be added to the database
        Console.WriteLine("Adding fruit: " + JsonSerializer.Serialize(_fruitList));
        var jsonContent = new StringContent(JsonSerializer.Serialize(_fruitList),
            Encoding.UTF8,
            "application/json");

        // Create the HTTP client using the FruitAPI named factory
        var httpClient = HttpClientFactory.CreateClient("FruitAPI");

        // Execute the POST request and store the response. The parameters in PostAsync 
        using HttpResponseMessage response = await httpClient.PostAsync("/fruits", jsonContent);

        // Return to the home (Index) page and add a temporary success/failure 
        // message to the page.
        if (response.IsSuccessStatusCode)
        {
            NavigationManager?.NavigateTo("/");
        }
        else
        {
            Console.WriteLine("Failed to add fruit");
        }
    }
    // End POST operation code
}
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using FruitWebApp.Models;
using System.Text.Json;
using System.Text;

namespace FruitWebApp.Components.Pages;

public partial class Delete : ComponentBase
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

    private async Task Submit()
    {
        // Something
    }
}
using Microsoft.AspNetCore.Components;
using FruitWebApp.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;

namespace FruitWebApp.Components.Pages;

public partial class Home : ComponentBase
{
    // IHttpClientFactory set using dependency injection 
    [Inject]
    public required IHttpClientFactory HttpClientFactory { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    /* Add the data model, enumerable since an array is expected as a response */
    private IEnumerable<FruitModel>? _fruitList;

    // Begin GET operation code

    // End GET operation code

    private void DeleteButton(int id) => NavigationManager!.NavigateTo($"/delete/{id}");
    private void EditButton(int id) => NavigationManager!.NavigateTo($"/edit/{id}");

}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FruitWebApp.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Diagnostics;

namespace FruitWebApp.Pages
{
	public class DeleteModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        // Add the data model and bind the form data to the page model properties
        [BindProperty]
        public FruitModel FruitModels { get; set; }


        // Retrieve the data to populate the form for deletion
        public async Task OnGet(int id)
        {

            // Create the HTTP client using the FruitAPI named factory
            var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            // Retrieve record information
            using HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response to populate the form
                using var contentStream = await response.Content.ReadAsStreamAsync();
                FruitModels = await JsonSerializer.DeserializeAsync<FruitModel>(contentStream);
            }
        }
		

		// Begin DELETE operation code
        
        // End DELETE operation code

	}
}


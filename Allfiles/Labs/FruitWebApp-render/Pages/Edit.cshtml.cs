using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FruitWebApp.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Diagnostics;

namespace FruitWebApp.Pages
{
	[BindProperties]
	public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        [Inject]
        public FruitModel FruitModels { get; set; }


        public async Task OnGet(int id)
        {
 
            var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            using HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                FruitModels = await JsonSerializer.DeserializeAsync<FruitModel>(contentStream);
            }
        }
		

		public async Task<IActionResult> OnPost()
		{
            var jsonContent = new StringContent(JsonSerializer.Serialize(FruitModels),
                Encoding.UTF8,
                "application/json");

			var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            using HttpResponseMessage response = await httpClient.PutAsync(FruitModels.id.ToString(), jsonContent);

			if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            return Page();

		}

	}
}


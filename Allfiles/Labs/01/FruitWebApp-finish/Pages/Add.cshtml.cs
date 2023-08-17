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
	public class AddModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        [Inject]
        public FruitModel FruitModels { get; set; }


        public void OnGet()
        {

        }
		

		public async Task<IActionResult> OnPost()
		{
            var jsonContent = new StringContent(JsonSerializer.Serialize(FruitModels),
                Encoding.UTF8,
                "application/json");

			var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            using HttpResponseMessage response = await httpClient.PostAsync("",jsonContent);

			if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            return Page();

		}

	}
}


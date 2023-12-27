using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FruitWebApp.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Diagnostics;


namespace FruitWebApp.Pages
{
    public class AddModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public AddModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        // Add the data model and bind the form data to the page model properties
        [BindProperty]
        public FruitModel FruitModels { get; set; }

        // Begin POST operation code
        public async Task<IActionResult> OnPost()
        {
            var jsonContent = 
                new StringContent(
                    JsonSerializer.Serialize(FruitModels),
                    Encoding.UTF8,
                    "application/json");

            var httpClient = _httpClientFactory.CreateClient("FruitAPI");

            using HttpResponseMessage response = await httpClient.PostAsync("", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Data was added successfully.";
                
                return RedirectToPage("Index");
            }
            else
            {
                TempData["failure"] = "Operation was not successful.";

                return RedirectToPage("Index");
            }
        }
        // End POST operation code
    }
}


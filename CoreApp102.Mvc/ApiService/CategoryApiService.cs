using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoreApp102.Mvc.DTOs;
using Newtonsoft.Json;

namespace CoreApp102.Mvc.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;

            var response = await _httpClient.GetAsync("Categories");
            //https://localhost:44333/api/categories
            if (response.IsSuccessStatusCode)
            {
                categoryDtos =
                    JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos = null;
            }

            return categoryDtos;

        }
    }
}

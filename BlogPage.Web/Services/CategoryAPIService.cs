using BlogPage.Core.DTOs;

namespace BlogPage.Web.Services
{
    public class CategoryAPIService
    {
        private readonly HttpClient _httpClient;

        public CategoryAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CategoryDTO> GetListAsync()
        {
            var response =  _httpClient.GetFromJsonAsync<CustomResponseDTO<List<CategoryDTO>>>("category").Result;
            return response.Data;
        }

        public CategoryDTO AddAsync(CategoryDTO categDto)
        {
            var response =  _httpClient.PostAsJsonAsync("category", categDto).Result;
            if (!response.IsSuccessStatusCode) return null;
            var responseBody =  response.Content.ReadFromJsonAsync<CustomResponseDTO<CategoryDTO>>().Result;
            return responseBody.Data;
        }

        public bool UpdateAsync(CategoryDTO categDto)
        {
            var response =  _httpClient.PutAsJsonAsync("category", categDto).Result;
            return response.IsSuccessStatusCode;
        }

        public bool DeleteAsync(int id)
        {
            var response = _httpClient.DeleteAsync($"category/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public CategoryDTO GetbyIdAsync(int id)
        {
            var response =  _httpClient.GetFromJsonAsync<CustomResponseDTO<CategoryDTO>>($"category/{id}").Result;
            return response.Data;
        }
    }
}

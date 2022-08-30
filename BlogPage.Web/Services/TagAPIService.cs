using BlogPage.Core.DTOs;

namespace BlogPage.Web.Services
{
    public class TagAPIService
    {
        private readonly HttpClient _httpClient;

        public TagAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<TagDTO> GetListAsync()
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<List<TagDTO>>>("tag").Result;
            return response.Data;
        }

        public TagDTO AddAsync(TagDTO tagDto)
        {
            var response = _httpClient.PostAsJsonAsync("tag", tagDto).Result;
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = response.Content.ReadFromJsonAsync<CustomResponseDTO<TagDTO>>().Result;
            return responseBody.Data;
        }

        public bool DeleteAsync(int id)
        {
            var response = _httpClient.DeleteAsync($"blog/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public TagDTO GetbyIdAsync(int id)
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<TagDTO>>($"tag/{id}").Result;
            return response.Data;
        }

        public List<BlogTagDTO> GetBlogTagAsync()
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<List<BlogTagDTO>>>("tag/GetBlogTag").Result;
            return response.Data;
        }
    }
}

using BlogPage.Core.DTOs;

namespace BlogPage.Web.Services
{
    public class BlogAPIService
    {
        private readonly HttpClient _httpClient;

        public BlogAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<BlogwithCategoryDTO> GetBlogwithCategoryAsync()
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<List<BlogwithCategoryDTO>>>("blog/GetBlogwithCategory").Result;
            return response.Data;
        }

        public List<BlogDTO> GetListAsync()
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<List<BlogDTO>>>("blog").Result;
            return response.Data;
        }

        public BlogDTO AddAsync(BlogDTO blogDto)
        {
            var response =  _httpClient.PostAsJsonAsync("blog", blogDto).Result;
            if(!response.IsSuccessStatusCode) return null;
            var responseBody = response.Content.ReadFromJsonAsync<CustomResponseDTO<BlogDTO>>().Result;
            return responseBody.Data;
        }

        public bool UpdateAsync(BlogDTO blogDto)
        {
            var response = _httpClient.PutAsJsonAsync("blog", blogDto).Result;
            return response.IsSuccessStatusCode;
        }

        public bool DeleteAsync(int id)
        {
            var response = _httpClient.DeleteAsync($"blog/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public BlogDTO GetbyIdAsync(int id)
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<BlogDTO>>($"blog/{id}").Result;
            return response.Data;
        }
    }
}

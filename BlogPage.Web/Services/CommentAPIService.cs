using BlogPage.Core.DTOs;

namespace BlogPage.Web.Services
{
    public class CommentAPIService
    {
        private readonly HttpClient _httpClient;

        public CommentAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CommentwithBlogDTO> GetCommentwithBlogAsync()
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<List<CommentwithBlogDTO>>>("comment/GetCommentwithBlog").Result;
            return response.Data;
        }

        public CommentDTO AddAsync(CommentDTO commentDto)
        {
            var response =  _httpClient.PostAsJsonAsync("comment", commentDto).Result;
            if (!response.IsSuccessStatusCode) return null;
            var responseBody =  response.Content.ReadFromJsonAsync<CustomResponseDTO<CommentDTO>>().Result;
            return responseBody.Data;
        }

        public bool DeleteAsync(int id)
        {
            var response = _httpClient.DeleteAsync($"comment/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public CommentDTO GetbyIdAsync(int id)
        {
            var response = _httpClient.GetFromJsonAsync<CustomResponseDTO<CommentDTO>>($"category/{id}").Result;
            return response.Data;
        }
    }
}

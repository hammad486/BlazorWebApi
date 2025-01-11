using BlazorWebApi.Models;

namespace BlazorWebApi.Services
{
    public class StudentServices
    {
        private readonly HttpClient _httpClient;

        public StudentServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Weather>> GetStudentsAsync()
        {
            _httpClient.BaseAddress = new Uri("http://34.196.58.97:5000/");
            return await _httpClient.GetFromJsonAsync<List<Weather>>("WeatherForecast");
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Student>($"api/Student/{id}");
        }

        public async Task AddStudentAsync(Student student)
        {
            await _httpClient.PostAsJsonAsync("api/Student", student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _httpClient.PutAsJsonAsync($"api/Student/{student.Id}", student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Student/{id}");
        }
    }
}
   

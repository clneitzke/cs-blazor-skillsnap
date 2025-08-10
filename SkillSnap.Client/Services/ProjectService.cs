using System.Net.Http.Json;
using SkillSnap.Shared.Models;

namespace SkillSnap.Client.Services
{
    public class ProjectService
    {
        private readonly HttpClient _http;

        public ProjectService(HttpClient http)
        {
            _http = http;
        }

        // Fetch all projects from API
        public async Task<List<Project>> GetProjectsAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Project>>("api/projects") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProjectService] Error: {ex.Message}");
                return new List<Project>();
            }
        }

        // Add a new project via POST
        public async Task AddProjectAsync(Project newProject)
        {
            try
            {
                await _http.PostAsJsonAsync("api/projects", newProject);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ProjectService] Error: {ex.Message}");
            }
        }
    }
}
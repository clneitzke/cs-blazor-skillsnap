using System.Net.Http.Json;
using SkillSnap.Shared.Models;

namespace SkillSnap.Client.Services
{
    public class ProjectService(HttpClient httpClient)
    {
        private const string ApiUrl = "http://localhost:5057/api/projects";

        public async Task<List<Project>?> GetProjectsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Project>>(ApiUrl);
        }

        public async Task AddProjectAsync(Project newProject)
        {
            await httpClient.PostAsJsonAsync(ApiUrl, newProject);
        }
    }
}
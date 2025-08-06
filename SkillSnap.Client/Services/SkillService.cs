using System.Net.Http.Json;
using SkillSnap.Shared.Models;

namespace SkillSnap.Client.Services
{
    public class SkillService(HttpClient httpClient)
    {
        private const string ApiUrl = "http://localhost:5057/api/skills";

        public async Task<List<Skill>> GetProjectsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Skill>>(ApiUrl);
        }

        public async Task AddProjectAsync(Skill newSkill)
        {
            await httpClient.PostAsJsonAsync(ApiUrl, newSkill);
        }
    }
}
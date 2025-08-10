using System.Net.Http.Json;
using SkillSnap.Shared.Models;

namespace SkillSnap.Client.Services
{
    public class SkillService
    {
        private readonly HttpClient _http;

        public SkillService(HttpClient http)
        {
            _http = http;
        }

        // Fetch all skills from API
        public async Task<List<Skill>> GetSkillsAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Skill>>("api/skills") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SkillService] Error: {ex.Message}");
                return new List<Skill>();
            }
        }

        // Add a new skill via POST
        public async Task AddSkillAsync(Skill newSkill)
        {
            try
            {
                await _http.PostAsJsonAsync("api/skills", newSkill);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SkillService] Error: {ex.Message}");
            }
        }
    }
}
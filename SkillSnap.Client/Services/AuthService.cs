using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SkillSnap.Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private readonly NavigationManager _navigation;

        public event Action? OnAuthStateChanged;

        private const string TokenKey = "authToken";

        public AuthService(HttpClient http, IJSRuntime js, NavigationManager navigation)
        {
            _http = http;
            _js = js;
            _navigation = navigation;
        }

        public async Task<bool> Login(string username, string password)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", new { username, password });

            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadFromJsonAsync<JwtResponse>();
            if (content is null) return false;

            await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, content.Token);
            _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", content.Token);
            OnAuthStateChanged?.Invoke();

            return true;
        }

        public async Task Logout()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
            _http.DefaultRequestHeaders.Authorization = null;
            OnAuthStateChanged?.Invoke();
            _navigation.NavigateTo("/");
        }

        public async Task<string?> GetToken()
        {
            return await _js.InvokeAsync<string>("localStorage.getItem", TokenKey);
        }

        public async Task<bool> IsLoggedIn()
        {
            var token = await GetToken();
            if (string.IsNullOrWhiteSpace(token)) return false;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.ValidTo > DateTime.UtcNow;
        }

        public async Task<string?> GetUsername()
        {
            var token = await GetToken();
            if (string.IsNullOrEmpty(token)) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var name = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return name;
        }

        private class JwtResponse
        {
            public string Token { get; set; } = string.Empty;
        }
    }
}

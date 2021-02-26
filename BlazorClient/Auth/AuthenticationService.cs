using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Auth.DTOs;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorClient.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _stateProvider;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider stateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _stateProvider = stateProvider;
        }
        public async Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication)
        {
            var content = JsonSerializer.Serialize(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var authResult = await _httpClient.PostAsync("account/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthResponseDto>(authContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (!authResult.IsSuccessStatusCode)
                return result;
            await _localStorage.SetItemAsync("authToken", result.Token);
            ((AuthStateProvider)_stateProvider).NotifyUserAuthentication(userForAuthentication.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new AuthResponseDto { IsAuthSuccessful = true };
        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_stateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public Task<string> RefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            throw new NotImplementedException();
        }
    }
}

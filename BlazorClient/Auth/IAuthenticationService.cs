using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorClient.Auth.DTOs;

namespace BlazorClient.Auth
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
        Task Logout();
        Task<string> RefreshToken();
    }
}

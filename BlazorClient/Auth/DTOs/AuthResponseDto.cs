using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Auth.DTOs
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}

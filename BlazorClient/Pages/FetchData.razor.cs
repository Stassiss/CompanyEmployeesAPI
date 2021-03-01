using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorClient.Auth;
using Microsoft.AspNetCore.Components;

namespace BlazorClient.Pages
{

    public partial class FetchData : IDisposable
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public HttpInterceptorService Interceptor { get; set; }
        private CompanyDto[] _companies;
        protected override async Task OnInitializedAsync()
        {
            Interceptor.RegisterEvent();
            _companies = await Http.GetFromJsonAsync<CompanyDto[]>("companies");
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }
    }
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorClient.Pages
{

    public partial class FetchData
    {
        [Inject]
        public HttpClient Http { get; set; }
        private CompanyDto[] _companies;
        protected override async Task OnInitializedAsync()
        {
            _companies = await Http.GetFromJsonAsync<CompanyDto[]>("companies");
        }
    }
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullAddress { get; set; }
    }

}

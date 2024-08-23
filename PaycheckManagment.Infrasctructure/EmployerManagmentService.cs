using Newtonsoft.Json;
using PaycheckManagment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaycheckManagment.Infrasctructure
{
    public class EmployerManagmentService : IEmployerManagmentService
    {
        private readonly HttpClient _httpClient;
        private const string URI_EMPLOYER_SERIVCE = "https://localhost:7142/Employee";
        public EmployerManagmentService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<long?> GetIdUserByFullName(string jsonContent)
        {
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{URI_EMPLOYER_SERIVCE}/GetIdUserByName", httpContent);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var resultId = JsonConvert.DeserializeObject<long?>(responseContent);
            return resultId;
        }
    }
}

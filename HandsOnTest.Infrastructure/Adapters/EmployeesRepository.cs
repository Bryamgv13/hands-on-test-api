using HandsOnTest.Domain.Dto;
using HandsOnTest.Domain.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using HandsOnTest.Infrastructure.Config;

namespace HandsOnTest.Infrastructure.Adapters
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IHttpClientFactory _HttpClientFactory;
        private readonly ApiEmployeesConfig _ApiEmployeesConfig;

        public EmployeesRepository(IHttpClientFactory httpClientFactory, ApiEmployeesConfig apiEmployeesConfig)
        {
            this._HttpClientFactory = httpClientFactory;
            this._ApiEmployeesConfig = apiEmployeesConfig;
        }

        public async Task<IEnumerable<EmployeesDto>> GetEmployees()
        {
            Uri uri = new Uri(_ApiEmployeesConfig.UrlEmployees);
            var cliente = _HttpClientFactory.CreateClient();
            var respuesta = await cliente.GetAsync(uri).ConfigureAwait(false);
            respuesta.EnsureSuccessStatusCode();
            IEnumerable<EmployeesDto> employees = JsonConvert.DeserializeObject<IEnumerable<EmployeesDto>>(await respuesta.Content.ReadAsStringAsync());
            return employees;
        }
    }
}

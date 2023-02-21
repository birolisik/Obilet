using Obilet.Application.Repositories.ServiceApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obilet.Infrastructure.Repositories.ServiceApi
{
    internal class ServiceApiRepository : IServiceApiRepository
    {
        private readonly IHttpClientFactory _factory;

        public ServiceApiRepository(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<Response> Get<Response, Request>(Request request, string url)
        {
             HttpClient httpClient = _factory.CreateClient("obilet");
             HttpResponseMessage respo = await httpClient.PostAsJsonAsync(url, request);
            return JsonSerializer.Deserialize<Response>(await respo.Content.ReadAsStringAsync());

        }
    }
}

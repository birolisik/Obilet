using Microsoft.AspNetCore.Http;
using Obilet.Application.Models.Sessions;
using Obilet.Application.Repositories.ServiceApi;
using Obilet.Application.Repositories.Session;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Infrastructure.Repositories.Session
{
    internal class SessionRepositories : ISessionRepository<SessionResponse> 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBrowserDetector _browserDetector;
        private readonly IServiceApiRepository _serviceApi;

        public SessionRepositories(IHttpContextAccessor httpContextAccessor, IBrowserDetector browserDetector, IServiceApiRepository serviceApi)
        {
            _httpContextAccessor = httpContextAccessor;
            _browserDetector = browserDetector;
            _serviceApi = serviceApi;
        }

        public async Task<SessionResponse> Get()
        {
            string ipadres = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString();
            int port = _httpContextAccessor.HttpContext.Connection.LocalPort;
            IBrowser browser = _browserDetector.Browser;
            SessionResponse session = await _serviceApi.Get<SessionResponse, SessionRequest>(
                new SessionRequest()
                {
                    Browser = new()
                    {
                        Name = browser.Name,
                        Version = browser.Version
                    },
                    Connection = new()
                    {
                        IpAddress = ipadres,
                        Port = port.ToString()
                    },
                    Type = 7
                }, "client/getsession");

            return session;
        }
    }
}

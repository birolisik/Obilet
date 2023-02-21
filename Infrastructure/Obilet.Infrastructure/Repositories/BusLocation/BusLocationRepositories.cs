using Obilet.Application.Models.BusLocations;
using Obilet.Application.Models.Sessions;
using Obilet.Application.Repositories;
using Obilet.Application.Repositories.BusLocation;
using Obilet.Application.Repositories.ServiceApi;
using Obilet.Application.Repositories.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Infrastructure.Repositories.BusLocation
{
    internal class BusLocationRepositories : IBusLocationRepository
    {
        private readonly IServiceApiRepository _serviceApi;
        private readonly ICookieManager _cookieManager;
        private readonly ISessionRepository<SessionResponse> _session;

        public BusLocationRepositories(IServiceApiRepository serviceApi, ICookieManager cookieManager, ISessionRepository<SessionResponse> session)
        {
            _serviceApi = serviceApi;
            _cookieManager = cookieManager;
            _session = session;
        }

        public async Task<BusLocationResponse> Get()
        {
            SessionResponse sessionResponse;
            if (_cookieManager.Get<SessionResponse>() == null)
            {
                sessionResponse = await _session.Get();
                _cookieManager.Set(sessionResponse);
                return await _serviceApi.Get<BusLocationResponse, BusLocationRequest>(new BusLocationRequest() { DeviceSession = new() { DeviceId = sessionResponse.DeviceSession.DeviceId, SessionId = sessionResponse.DeviceSession.SessionId } }, "location/getbuslocations");
            }
            else
            {
                sessionResponse = _cookieManager.Get<SessionResponse>();
                return await _serviceApi.Get<BusLocationResponse, BusLocationRequest>(new BusLocationRequest() { DeviceSession = new() { DeviceId = sessionResponse.DeviceSession.DeviceId, SessionId = sessionResponse.DeviceSession.SessionId } }, "location/getbuslocations");
            }
        }

        public async Task<BusLocationResponse> Get(string search)
        {
            SessionResponse sessionResponse;
            if (_cookieManager.Get<SessionResponse>() == null)
            {
                sessionResponse = await _session.Get();
                _cookieManager.Set(sessionResponse);
                return await _serviceApi.Get<BusLocationResponse, BusLocationRequest>(new BusLocationRequest() { DeviceSession = new() { DeviceId = sessionResponse.DeviceSession.DeviceId, SessionId = sessionResponse.DeviceSession.SessionId }, SearchData = search }, "location/getbuslocations");
            }
            else
            {
                sessionResponse = _cookieManager.Get<SessionResponse>();
                return await _serviceApi.Get<BusLocationResponse, BusLocationRequest>(new BusLocationRequest() { DeviceSession = new() { DeviceId = sessionResponse.DeviceSession.DeviceId, SessionId = sessionResponse.DeviceSession.SessionId }, SearchData = search }, "location/getbuslocations");
            }
        }
    }
}

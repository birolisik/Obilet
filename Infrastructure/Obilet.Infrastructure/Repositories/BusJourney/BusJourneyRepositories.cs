using Obilet.Application.Models.BusJourneys;
using Obilet.Application.Models.Sessions;
using Obilet.Application.Repositories;
using Obilet.Application.Repositories.BusJourney;
using Obilet.Application.Repositories.ServiceApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Infrastructure.Repositories.BusJourney
{
    internal class BusJourneyRepositories : IBusJourneyRepository
    {
        private readonly IServiceApiRepository _serviceApi;
        private readonly ICookieManager _cookieManager;

        public BusJourneyRepositories(IServiceApiRepository serviceApi, ICookieManager cookieManager)
        {
            _serviceApi = serviceApi;
            _cookieManager = cookieManager;
        }

        public async Task<BusJourneyResponse> Get(BusJourneyRequest.JourneyDataItem model)
        {
            SessionResponse sessionResponse = _cookieManager.Get<SessionResponse>();

            BusJourneyResponse response = await _serviceApi.Get<BusJourneyResponse, BusJourneyRequest>(new BusJourneyRequest()
            {
                DeviceSession = new()
                {
                    DeviceId = sessionResponse.DeviceSession.DeviceId,
                    SessionId = sessionResponse.DeviceSession.SessionId
                },
                JourneyData = new()
                {
                    DepartureDate = model.DepartureDate,
                    DestinationId = model.DestinationId,
                    OriginId = model.OriginId,
                }
            }, "journey/getbusjourneys"); ;



            return response;
        }
    }
}

using Obilet.Application.Models.BusJourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Application.Repositories.BusJourney
{
    public interface IBusJourneyRepository 
    {
        Task<BusJourneyResponse> Get(BusJourneyRequest.JourneyDataItem model);
    }
}

using Obilet.Application.Models.BusLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Application.Repositories.BusLocation
{
    public interface IBusLocationRepository
    {
        Task<BusLocationResponse> Get();

        Task<BusLocationResponse> Get(string search);
    }
}

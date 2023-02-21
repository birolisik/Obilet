using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Application.Repositories.ServiceApi
{
    public interface IServiceApiRepository
    {
        Task<Response> Get<Response, Request>(Request request, string url);
    }
}

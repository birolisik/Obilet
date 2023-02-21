using Obilet.Application.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Application.Repositories.Session
{
    public interface ISessionRepository<T> where T : class
    {
        Task<T> Get();
    }
}

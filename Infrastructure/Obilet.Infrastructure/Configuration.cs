using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Infrastructure
{
    public class Configuration
    {
        public string Get(string path)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Obilet.Web"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetSection(path).Value;
        }
    }
}

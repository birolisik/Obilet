using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Application.ViewModels
{
    public class VM_BusLocation
    {
        public int OriginId { get; set; }
        public string? Origin { get; set; }
        public int DestinationId { get; set; }
        public string? Destination { get; set; }
        public DateTime DepartureDate { get; set; } = DateTime.Now;
    }
}

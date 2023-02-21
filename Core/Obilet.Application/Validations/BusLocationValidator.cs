using FluentValidation;
using Obilet.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Application.Validations
{
    public class BusLocationValidator:AbstractValidator<VM_BusLocation>
    {
        public BusLocationValidator()
        {
            RuleFor(r => r.Origin).NotNull().WithMessage(r=> "Başlangıç lokasyonu boş geçilemez.");
            RuleFor(r => r.Destination).NotNull().WithMessage("Varış lokasyonu boş geçilemez.");
            RuleFor(r => r.OriginId).NotEqual(r => r.DestinationId).WithMessage("Başlagıç ve Bitiş lokasyonu aynı olamaz");
            RuleFor(r => r.DepartureDate).GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("En erken tarih bugün olabilir");
        }
      
    }
}

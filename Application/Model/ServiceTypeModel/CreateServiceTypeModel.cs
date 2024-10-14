using Application.ModelUtil.ModelBinding;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.ServiceTypeModel
{
    public class CreateServiceTypeModel
    {
        public string TypeName { get; set; }
        public string? ServiceLocation { get; set; }
        [ModelBinder(BinderType = typeof(NullableGuidModelBinder))]
        public Guid? TravelExpenseId { get; set; }
    }
}

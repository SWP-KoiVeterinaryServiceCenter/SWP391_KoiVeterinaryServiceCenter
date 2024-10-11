using Application.ModelUtil.ModelBinding;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.KoiServiceModel
{
    public class CreateServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid TypeId {  get; set; }
      /*  [ModelBinder(BinderType = typeof(NullableGuidModelBinder))]*/
        public Guid? TankId { get; set; }
        public IFormFile serviceImage { get; set; }
        public int Duration { get; set; }
    }
}

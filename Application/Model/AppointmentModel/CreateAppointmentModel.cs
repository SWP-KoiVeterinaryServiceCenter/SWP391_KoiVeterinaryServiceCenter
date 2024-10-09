using Application.ModelUtil.ModelBinding;
using Application.ModelUtil.ModelValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Model.AppointmentModel
{
    public class CreateAppointmentModel
    {
        public string Description { get; set; }
        public Guid ServiceId { get; set; }
        public Guid KoiId { get; set; }
        [ModelBinder(BinderType = typeof(NullableGuidModelBinder))]
        public Guid? VeterinarianId { get; set; }
        [DataType(DataType.Date)]
        public string AppointmentDate {  get; set; }
        [TimeRange]
        public int AppointmentTime { get; set; }
    }
}

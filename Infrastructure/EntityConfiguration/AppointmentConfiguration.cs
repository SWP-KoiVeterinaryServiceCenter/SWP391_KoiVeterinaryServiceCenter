using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfiguration
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(x => x.Service).WithOne(ser => ser.Appointment).HasForeignKey<Appointment>(x => x.ServiceId);
            builder.HasOne(x => x.MedicalRecord).WithOne(rec => rec.Appointment).HasForeignKey<Appointment>(x => x.MedicalRecordId);
        }
    }
}
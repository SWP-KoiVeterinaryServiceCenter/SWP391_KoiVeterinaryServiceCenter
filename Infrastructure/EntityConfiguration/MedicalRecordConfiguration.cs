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
    internal class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasOne(x=>x.Appointment).WithOne(record=>record.MedicalRecord).HasForeignKey<MedicalRecord>(x=>x.AppointmentId);
        }
    }
}

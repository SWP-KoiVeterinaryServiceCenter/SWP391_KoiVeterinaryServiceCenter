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
    internal class MedicalPrescriptionConfiguration : IEntityTypeConfiguration<MedicalPrescription>
    {
        public void Configure(EntityTypeBuilder<MedicalPrescription> builder)
        {
            builder.HasOne(x => x.MedicalRecordLink).WithMany(x => x.Prescriptions).HasForeignKey(x => x.MedicalRecordId);
        }
    }
}

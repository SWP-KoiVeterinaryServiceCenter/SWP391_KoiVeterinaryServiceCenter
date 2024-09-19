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
    internal class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(x => x.RatingAppointment).WithOne(x => x.Rating).HasForeignKey<Rating>(x => x.AppointmentId);
        }
    }
}

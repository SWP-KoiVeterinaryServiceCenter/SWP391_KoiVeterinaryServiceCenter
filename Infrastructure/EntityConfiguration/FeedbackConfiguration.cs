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
    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasOne(x => x.FeedbackAppointment).WithOne(x => x.Feedback).HasForeignKey<Feedback>(x => x.AppointmentId);
        }
    }
}

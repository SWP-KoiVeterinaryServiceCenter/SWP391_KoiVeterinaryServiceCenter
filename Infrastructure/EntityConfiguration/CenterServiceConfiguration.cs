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
    internal class CenterServiceConfiguration : IEntityTypeConfiguration<CenterService>
    {
        public void Configure(EntityTypeBuilder<CenterService> builder)
        {
            builder.HasOne(x=>x.ServiceType).WithMany(x=>x.ListServices).HasForeignKey(x=>x.TypeId);
            builder.HasOne(x=>x.Tank).WithMany(x=>x.ServiceList).HasForeignKey(x=>x.TankId);
        }
    }
}

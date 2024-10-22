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
    internal class AccountScheduleConfiguration : IEntityTypeConfiguration<AccountSchedule>
    {
        public void Configure(EntityTypeBuilder<AccountSchedule> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.AccountId, x.ScheduleId });
            builder.HasOne(x => x.Account).WithMany(acc => acc.AccountSchedules).HasForeignKey(x => x.AccountId);
            builder.HasOne(x => x.WorkingSchedule).WithMany(sche => sche.AccountSchedules).HasForeignKey(x => x.ScheduleId);
        }
    }
}

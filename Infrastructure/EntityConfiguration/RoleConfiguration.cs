using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfiguration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                RoleId = 1,
                RoleName=nameof(RoleEnum.Admin),
            },
            new Role
            {
                RoleId = 2,
                RoleName = nameof(RoleEnum.Staff),
            },
            new Role
            {
                RoleId = 3,
                RoleName = nameof(RoleEnum.Veterian),
            }, 
            new Role { 
                RoleId = 4,
                RoleName = nameof(RoleEnum.Customer) 
            });
        }
    }
}

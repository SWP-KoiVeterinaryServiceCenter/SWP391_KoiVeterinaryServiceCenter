using Application.Util;
using Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfiguration
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
           builder.HasIndex(x=>x.Email).IsUnique();
            builder.HasData(new Account
            {
                Id=Guid.Parse("1de7660a-5288-440c-af13-9914662f155c"),
                Email = "admin@gmail.com",
                PasswordHash = new string("Admin@123").Hash(),
                CreationDate= DateTime.UtcNow,
                ContactLink="",
                Fullname="Admin",
                RoleId=1,
                Username="Admin",
                Location="",
                Phonenumber="",
            },
            new Account
            {
                Id=Guid.Parse("dc699c6a-3980-42dd-be75-d10ae89c82b3"),
                Email = "staff@gmail.com",
                PasswordHash = new string("Staff@123").Hash(),
                CreationDate = DateTime.UtcNow,
                ContactLink = "",
                Fullname = "Staff",
                RoleId = 2,
                Username = "Staff",
                Location = "",
                Phonenumber = "",
            }
            ) ;
        }
    }
}

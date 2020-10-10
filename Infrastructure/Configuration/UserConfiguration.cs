using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder
                .Property(e => e.Nome)
                .IsRequired();

            builder
                .Property(e => e.Cpf)
                .IsRequired();

            builder
                .Property(e => e.Login)
                .IsRequired();

            builder
                .Property(e => e.Password)
                .IsRequired();

            builder.HasOne(x => x.Role).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}

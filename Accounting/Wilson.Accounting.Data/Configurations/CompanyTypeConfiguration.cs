﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilson.Accounting.Core.Entities;

namespace Wilson.Accounting.Data.Configurations
{
    public class CompanyTypeConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyTypeConfiguration(ModelBuilder modelBuilder)
        {
            this.Map(modelBuilder.Entity<Company>());
        }

        public override void Map(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(70).IsRequired();
            builder.Property(x => x.IndetificationNumber).HasMaxLength(9).IsRequired();
            builder.Property(x => x.VatNumber).HasMaxLength(11);
            builder.HasMany(x => x.Employees).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        }
    }
}
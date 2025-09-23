using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Infrastructure.Persistance
{
    public class LeadManagerDbContext : DbContext
    {
        public LeadManagerDbContext(DbContextOptions<LeadManagerDbContext> options)
            : base(options) { }

        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lead>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.FullName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(l => l.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(l => l.Email)
                .IsUnique();

                entity.Property(l => l.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(l => l.Suburb)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(l => l.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(l => l.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(l => l.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");
            });
        }

    }
}

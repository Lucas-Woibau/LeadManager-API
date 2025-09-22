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
    }
}

using LeadManager.Domain.Entities;
using LeadManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Infrastructure.Seed
{
    public static class LeadManagerDbContextSeed
    {
        public static async Task SeedAsync(LeadManagerDbContext context)
        {
            if (!await context.Leads.AnyAsync())
            {
                var leads = new List<Lead>
                {
                    new Lead("Lucas Andrade", "lucas@email.com", "11999999999",
                        "São Paulo", "Construção", "Preciso de orçamento de reforma", 750m),

                    new Lead("Mariana Silva", "mariana@email.com", "21988888888",
                        "Rio de Janeiro", "Elétrica", "Instalação de rede elétrica residencial", 300m),

                    new Lead("Carlos Souza", "carlos@email.com", "31977777777",
                        "Belo Horizonte", "Pintura", "Pintura de fachada comercial", 1200m)
                };

                context.Leads.AddRange(leads);
                await context.SaveChangesAsync();
            }
        }
    }
}

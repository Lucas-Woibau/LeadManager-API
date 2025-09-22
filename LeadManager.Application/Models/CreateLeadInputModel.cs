using LeadManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Application.Models
{
    public class CreateLeadInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Lead ToEntity()
            => new(FullName, Email, PhoneNumber, Suburb, Category, Description, Price);
    }
}

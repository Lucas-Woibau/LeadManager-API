using LeadManager.Domain.Entities;
using LeadManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Application.Models
{
    public class LeadViewModel
    {
        public LeadViewModel(int id, string fullName, string email, string phoneNumber, string suburb, string category, string description, decimal price)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Suburb { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public static LeadViewModel FromEntity(Lead entity)
            => new(entity.Id, entity.FullName, entity.Email, entity.PhoneNumber,
                 entity.Suburb, entity.Category, entity.Description, entity.Price);
    }
}

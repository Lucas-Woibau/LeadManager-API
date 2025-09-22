using LeadManager.Domain.Entities;
using LeadManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Application.Models
{
    public class LeadItemViewModel
    {
        public LeadItemViewModel(int id, string fullName, string email, string phoneNumber, DateTime dateCreated, string suburb, string category, string description, decimal price, LeadStatus status)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateCreated = dateCreated;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            Status = status;
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string Suburb { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public LeadStatus Status { get; private set; }

        public static LeadItemViewModel FromEntity(Lead entity)
            => new(entity.Id, entity.FullName, entity.Email, entity.PhoneNumber,
                 entity.DateCreated,entity.Suburb, entity.Category, entity.Description,
                 entity.Price, entity.Status);
    }
}

using LeadManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Domain.Entities
{
    public class Lead
    {
        public Lead() { }
        public Lead(string fullName, string email, string phoneNumber, string suburb, string category, string description, decimal price)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;

            DateCreated = DateTime.Now;
            Status = LeadStatus.Invited;
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

        public bool Accept()
        {
            if (Status != LeadStatus.Invited)
                return false;

            Status = LeadStatus.Accepted;
            ApplyDiscount();
            return true;
        }

        public bool Decline()
        {
            if (Status != LeadStatus.Invited)
                return false;

            Status = LeadStatus.Declined;
            return true;
        }

        private void ApplyDiscount()
        {
            if (Price > 500)
                Price *= 0.9m;
        }

        public void Update(string fullName, string email, string phoneNumber, string suburb, string category, string description, decimal price)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;

            if (Status == LeadStatus.Accepted)
                ApplyDiscount();
        }
    }
}

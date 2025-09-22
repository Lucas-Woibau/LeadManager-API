using LeadManager.Application.Models;
using LeadManager.Domain.Enums;
using LeadManager.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly LeadManagerDbContext _context;

        public LeadService(LeadManagerDbContext context)
        {
            _context = context;
        }
        public ResultViewModel<List<LeadItemViewModel>> GetAll()
        {
            var leads = _context.Leads
                .Where(l => l.Status != LeadStatus.Declined)
                .ToList();

            var model = leads.Select(LeadItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<LeadItemViewModel>>.Success(model);
        }

        public ResultViewModel<LeadViewModel> GetById(int id)
        {
            var leads = _context.Leads
                .SingleOrDefault(p => p.Id == id);

            if (leads == null)
                return ResultViewModel<LeadViewModel>.Error("Lead não existe!");

            var model = LeadViewModel.FromEntity(leads);

            return ResultViewModel<LeadViewModel>.Success(model);
        }

        public ResultViewModel<int> Create(CreateLeadInputModel model)
        {
            var lead = model.ToEntity();

            _context.Leads.Add(lead);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(lead.Id);
        }

        public ResultViewModel Update(UpdateLeadInputModel model)
        {
            var lead = _context.Leads.SingleOrDefault(p => p.Id == model.IdLead);

            if (lead == null)
                return ResultViewModel<LeadViewModel>.Error("Lead não existe!");

            lead.Update(model.FullName, model.Email, model.PhoneNumber, model.Suburb, model.Category, model.Description, model.Price);
            _context.Leads.Update(lead);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var lead = _context.Leads.SingleOrDefault(p => p.Id == id);

            if (lead == null)
                return ResultViewModel<LeadViewModel>.Error("Lead não existe!");

            _context.Leads.Remove(lead);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Accept(int id)
        {
            var lead = _context.Leads.SingleOrDefault(l => l.Id == id);

            if (lead == null)
                return ResultViewModel.Error("Lead não existe!");

            lead.Accept();
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Declined(int id)
        {
            var lead = _context.Leads.SingleOrDefault(l => l.Id == id);

            if (lead == null)
                return ResultViewModel.Error("Lead não existe!");

            lead.Decline();
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}

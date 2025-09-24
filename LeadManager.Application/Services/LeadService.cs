using LeadManager.Application.Models;
using LeadManager.Domain.Enums;
using LeadManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
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
        private readonly IEmailService _emailService;

        public LeadService(LeadManagerDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public async Task<ResultViewModel<List<LeadItemViewModel>>> GetAllInvitedAndAccepted()
        {
            var leads = await _context.Leads
                .Where(l => l.Status == LeadStatus.Invited
                || l.Status == LeadStatus.Accepted)
                .ToListAsync();

            var model = leads.Select(LeadItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<LeadItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<LeadViewModel>> GetById(int id)
        {
            var leads = await _context.Leads
                .SingleOrDefaultAsync(p => p.Id == id);

            if (leads == null)
                return ResultViewModel<LeadViewModel>.Error("Lead não existe!");

            var model = LeadViewModel.FromEntity(leads);

            return ResultViewModel<LeadViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> Create(CreateLeadInputModel model)
        {
            var lead = model.ToEntity();

            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(lead.Id);
        }

        public async Task<ResultViewModel> Update(UpdateLeadInputModel model)
        {
            var lead = await _context.Leads.SingleOrDefaultAsync(p => p.Id == model.IdLead);

            if (lead == null)
                return ResultViewModel<LeadViewModel>.Error("Lead não existe!");

            lead.Update(model.FullName, model.Email, model.PhoneNumber, model.Suburb, model.Category, model.Description, model.Price);
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Delete(int id)
        {
            var lead = await _context.Leads.SingleOrDefaultAsync(p => p.Id == id);

            if (lead == null)
                return ResultViewModel<LeadViewModel>.Error("Lead não existe!");

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Accept(int id)
        {
            var lead = await _context.Leads.SingleOrDefaultAsync(l => l.Id == id);

            if (lead == null)
                return ResultViewModel.Error("Lead não existe!");

            if (!lead.Accept())
                return ResultViewModel.Error("O lead não pode ser aceito.");

            await _context.SaveChangesAsync();

            var subject = "New lead accepted";
            var body = $"The lead {lead.FullName} has been accepted. Price: {lead.Price:C}";
            await _emailService.SendEmailAsync("vendas@test.com", subject, body);

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> Declined(int id)
        {
            var lead = await _context.Leads.SingleOrDefaultAsync(l => l.Id == id);

            if (lead == null)
                return ResultViewModel.Error("Lead não existe!");

            if (!lead.Decline())
                return ResultViewModel.Error("O lead não pode ser recusado.");

            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}

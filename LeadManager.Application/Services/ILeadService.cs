using LeadManager.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManager.Application.Services
{
    public interface ILeadService
    {
        Task<ResultViewModel<List<LeadItemViewModel>>> GetAllInvitedAndAccepted();
        Task<ResultViewModel<LeadViewModel>> GetById(int id);
        Task<ResultViewModel<int>> Create(CreateLeadInputModel model);
        Task<ResultViewModel> Update(UpdateLeadInputModel model);
        Task<ResultViewModel> Delete(int id);
        Task<ResultViewModel> Accept(int id);
        Task<ResultViewModel> Declined(int id);
    }
}

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
        ResultViewModel<List<LeadItemViewModel>> GetAll();
        ResultViewModel<LeadViewModel> GetById(int id);
        ResultViewModel<int> Create(CreateLeadInputModel model);
        ResultViewModel Update(UpdateLeadInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel Accept(int id);
        ResultViewModel Declined(int id);
    }
}

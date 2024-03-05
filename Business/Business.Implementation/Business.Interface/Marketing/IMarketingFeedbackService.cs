using Business.Entities.Designation;
using Business.Entities.Marketing.Feedback;
using Business.Entities.PartyMasterModel;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Marketing
{
    public interface IMarketingFeedbackService
    {
        Task<PagedDataTable<MarketingFeedback>> GetAllMarketingFeedbackAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "DepartmentID", string sortBy = "ASC", int userId = 0);
        Task<int> MarketingFeedbackCreateAsync(MarketingFeedback marketingFeedback, DataTable dataTable);

        Task<MarketingFeedback> GetMarketingFeedbackAsync(int MarketingFeedbackID);

        MarketingFeedback GetForm(int id, int MarketingFeedbackID);

        PagedDataTable<MarketingFeedback> GetAllFeedbackNote();
        PagedDataTable<PartyMaster> GetAllPartyMaster();
    }
}

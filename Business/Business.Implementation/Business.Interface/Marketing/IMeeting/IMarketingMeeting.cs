using Business.Entities.Marketing.Meeting;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IMeeting
{
    public interface IMarketingMeeting
    {
        Task<PagedDataTable<MarketingMeeting>> GetAllMarketingMeetingAsync(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "DepartmentID", string sortBy = "ASC", int userId = 0);
        Task<MarketingMeeting> GetMarketingMeetingAsync(int id);
        Task<int> MarketingMeetingInsertOrUpdateAsync(MarketingMeeting MarketingMeeting);

        //Task<PagedDataTable<MarketingMeeting>> GetAllMarketingMeetingAsync();
        Task<PagedDataTable<MarketingMeeting>> GetAllMarketingMeetingPartyWiseAsync(int pageNo = 1, int pageSize = 5, string searchString = "", string orderBy = "DepartmentID", string sortBy = "ASC", int userId =    0, int PartyID = 0);
    }
}

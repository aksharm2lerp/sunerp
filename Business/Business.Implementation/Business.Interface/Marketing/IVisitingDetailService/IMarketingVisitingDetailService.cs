using Business.Entities.Marketing.VisitingDetail;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IVisitingDetailService
{
    public interface IMarketingVisitingDetailService
    {
        Task<PagedDataTable<VisitingDetail>> GetAllMarketingVisitingDetailAsync(int pageNo, int pageSize, string searchString = "", string orderBy = "MarketingVisitedDetailID", string sortBy = "ASC", int userId = 0);
        Task<int> MarketingVisitingDetailInsertOrUpdateAsync(VisitingDetail VisitedDetail);
        Task<VisitingDetail> GetMarketingVisitingDetailAsync(int MarketingVisitiedDetailID);


    }
}

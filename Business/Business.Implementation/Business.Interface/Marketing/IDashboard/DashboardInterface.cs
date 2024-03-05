using Business.Entities.Marketing.Dashboard;
using Business.Entities.PartyMasterModel;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IDashboard
{
    public interface DashboardInterface
    {
    //    DashboardModel GetUserLoginList(DateTime? startDate, DateTime? endDate);
        Task<DashboardModel> GetUserLoginList(DateTime? startDate, DateTime? endDate);
    }
}

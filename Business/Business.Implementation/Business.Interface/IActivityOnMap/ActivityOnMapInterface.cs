using Business.Entities.ActivityOnMapModel;
using Business.SQL;
using System;
using System.Threading.Tasks;

namespace Business.Interface.IActivityOnMap
{
    public interface ActivityOnMapInterface
    {
        /*Task<List<string>> GetGoogleMapAsync(int employeeId);*/
        #region Using Table View For Google Map Location start
        Task<PagedDataTable<ActivityOnMap>> GetAllLocationList(int uid, String startDate);
        #endregion Using Table View For Google Map Location end

    }
}

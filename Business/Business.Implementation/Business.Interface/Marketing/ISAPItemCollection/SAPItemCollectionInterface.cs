using Business.Entities.Marketing.SAPItem;
using Business.Entities.PartyMasterModel;
using Business.SQL;
using System.Data;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.ISAPItemCollection
{
    public interface SAPItemCollectionInterface
    {
         

        Task<PagedDataTable<SAPUpdateItemStock>> GetAllSAPItemStockList(int pageNo = 1, int pageSize = 10, string searchString = "", string orderBy = "PartyID", string sortBy = "ASC", string ItemGroupName = "", string WareHouse  = "");
        //Task<PagedDataTable<SAPUpdateItemStock>> GetAllSAPItemStockListAsync(string SearchString, string ItemGroupName);
        Task<PagedDataTable<SAPItemGroup>> GetAllSAPItemGroupAsync();
        Task<PagedDataTable<WareHouse>> GetAllSAPWareHouseAsync();
        Task<DataTable> GetCustomerListByItemCodeAsync(string itemCode);
        Task<DataTable> GetClientSalesSummaryAsync(string itemCode, string customerName);
    }
}

using Business.Interface;
using Business.Interface.Marketing;
using Business.Interface.Marketing.ISAPItemCollection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ERP.Extensions
{
    public class MarketingExtension
    {
        private static HttpContext Current => new HttpContextAccessor().HttpContext;
        public static IMasterService _masterService => (IMasterService)Current.RequestServices.GetService(typeof(IMasterService));
        public static IMarketingFeedbackService _iMarketingFeedbackService => (IMarketingFeedbackService)Current.RequestServices.GetService(typeof(IMarketingFeedbackService));

        public static SAPItemCollectionInterface _sapItemCollectionInterface   => (SAPItemCollectionInterface)Current.RequestServices.GetService(typeof(SAPItemCollectionInterface));

        public static SelectList GetAllMarketingClientFeedbackNote()
        {
            try
            {
                var FeedbackNote = _iMarketingFeedbackService.GetAllFeedbackNote();
                return new SelectList(FeedbackNote, "PositiveNoteID", "PositiveNoteText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        public static SelectList GetAllPartyName()
        {
            try
            {
                var partyNames = _iMarketingFeedbackService.GetAllPartyMaster();
                return new SelectList(partyNames, "PartyID", "PartyName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }


        #region GetAllSAPItemGroupAsync - Employee Dropdown List filter by Department
        public static SelectList GetAllSAPItemGroupAsync()
        {
            try
            {
                var ListObject = _sapItemCollectionInterface.GetAllSAPItemGroupAsync().Result;
                return new SelectList(ListObject, "ItemGroupName", "ItemGroupName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllSAPItemGroupAsync - Employee Dropdown List


        #region GetAllSAPItemGroupAsync - Employee Dropdown List filter by Department
        public static SelectList GetAllSAPWareHouseAsync()
        {
            try
            {
                var ListObject = _sapItemCollectionInterface.GetAllSAPWareHouseAsync().Result;
                return new SelectList(ListObject, "Warehouse", "Warehouse");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion GetAllSAPItemGroupAsync - Employee Dropdown List


    }
}

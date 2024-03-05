using Business.Interface;
using Microsoft.AspNetCore.Http;
using Business.Interface.IParty;
using System.Collections.Generic;
using System.Linq;
using Business.Entities.Party;
using Business.Entities.PartyType;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business.Interface.IPartyTypeService;

namespace ERP.Extensions
{
    public class PartyExtension
    {
        private static HttpContext Current => new HttpContextAccessor().HttpContext;
        public static IMasterService _masterService => (IMasterService)Current.RequestServices.GetService(typeof(IMasterService));
        public static IPartyService _PartyService => (IPartyService)Current.RequestServices.GetService(typeof(IPartyService));
        public static IPartyTypeService _PartyTypeService => (IPartyTypeService)Current.RequestServices.GetService(typeof(IPartyTypeService));

        public static SelectList GetAllIndustryTypeMaster()
        {
            try
            {
                var listIndustryType = _masterService.GetAllIndustryTypeMaster();
                return new SelectList(listIndustryType, "IndustryTypeID", "IndustryTypeText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        public static SelectList GetAllBusinessTypeMaster()
        {
            try
            {
                var listBusinessType = _masterService.GetAllBusinessTypeMaster();
                return new SelectList(listBusinessType, "BusinessTypeID", "BusinessTypeText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        public static SelectList GetAllPartyTypeMaster()
        {
            try
            {
                var listPartyType = _PartyTypeService.GetPartyTypeMasterAsync();
                return new SelectList(listPartyType, "PartyTypeID", "PartyTypeText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        public static SelectList GetAllDepartments()
        {
            try
            {
                var listDepartment = _masterService.GetAllDepartments();
                return new SelectList(listDepartment, "DepartmentID", "DepartmentName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        public static SelectList GetAllDesignations()
        {
            try
            {
                var listDesignation = _masterService.GetAllDesignations();
                return new SelectList(listDesignation, "DesignationID", "DesignationText");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        public static List<PartyContactTxn> ListOfPartyContactPerson(int PartyId)
        {
            try
            {
                List<PartyContactTxn> pds = _PartyService.GetPartyAllContactPerson(1, 10, "", "PartyID", "1", PartyId).Result;
                return pds;
            }
            catch
            {
                return null;
            }
        }

        public static List<PartyAddressTxn> ListOfPartyAddress(int PartyId)
        {
            try
            {
                List<PartyAddressTxn> pds = _PartyService.GetPartyAllAddressAsync(1, 10, "", "PartyID", "1", PartyId).Result;
                return pds;
            }
            catch
            {
                return null;
            }
        }

        public static PartyContactDetail GetPartyContactDetail(int PartyId)
        {
            try
            {
                PartyContactDetail PartyContactDetail = new PartyContactDetail();
                PartyContactDetail.PartyID = PartyId;

                var contactDetail = _PartyService.GetPartyContactDetail(PartyId).Result;

                if (contactDetail != null)
                    PartyContactDetail = contactDetail;

                return PartyContactDetail;
            }
            catch
            {
                return null;
            }
        }

        public static PartyRegistration GetPartyRegistration(int PartyId)
        {
            try
            {
                PartyRegistration PartyRegistration = new PartyRegistration();
                PartyRegistration.PartyID = PartyId;

                var registration = _PartyService.GetPartyRegistration(PartyId).Result;

                if (registration != null)
                    PartyRegistration = registration;

                return PartyRegistration;
            }
            catch
            {
                return null;
            }
        }

        public static List<PartyBankDetails> GetPartyAllBankAccount(int PartyId)
        {
            try
            {
                List<PartyBankDetails> pds = _PartyService.GetPartyAllBankAccount(1, 10, "", "BankName", "1", PartyId).Result;
                return pds;
            }
            catch
            {
                return null;
            }
        }

        public static SelectList GetAllDocumentType()
        {
            try
            {
                var role = _masterService.GetAllDocumentTypeAsync().Result;
                return new SelectList(role, "DocumentTypeID", "DocumentTypeName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        public static List<PartyDocument> GetPartysAllDocuments(int PartyId)
        {
            try
            {
                List<PartyDocument> pds = _PartyService.GetPartysAllDocuments(1, 10, "", "PartyID", "1", PartyId).Result;
                return pds;
            }
            catch
            {
                return null;
            }
        }

        public static PartySetting GetPartySetting(int PartyId)
        {
            try
            {
                PartySetting PartySetting = new PartySetting();
                PartySetting.PartyID = PartyId;

                var setting = _PartyService.GetPartySetting(PartyId).Result;

                if (setting != null)
                    PartySetting = setting;

                return PartySetting;
            }
            catch
            {
                return null;
            }
        }
        #region Party Dropdown List

        public static SelectList GetAllPartyAsync()
        {
            try
            {
                var role = _PartyService.GetAllPartyAsync().Result;
                return new SelectList(role, "PartyID", "PartyName");
            }
            catch
            {
                return new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }
        #endregion Party Dropdown List

    }
}

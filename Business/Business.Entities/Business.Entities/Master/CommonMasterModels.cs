using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Master
{
    public class ObjectMaster
    {
        public int ObjectID { get; set; }
        public string ObjectName { get; set; }
    }

    public class CityMasterModelDropdown
    {
        public int CityID { get; set; }
        public string CityName { get; set; }

    }

    
 public class AddressMasterModelDropdown
    {
        public int AddressIDID { get; set; }
        public string AddressName { get; set; }
    }
 
 	 
 public class RoleMasterModelDropdown
    {
        public int RoleIDID { get; set; }
        public string RoleName { get; set; }
    }
 
 	 
 public class ExpenseTypeMasterModelDropdown
    {
        public int ExpenseTypeID { get; set; }
        public string ExpenseTypeText { get; set; }
    }
 
 	 
 public class ItemGroupMasterModelDropdown
    {
        public int ItemGroupID { get; set; }
        public string ItemGroupName { get; set; }
    }
    public class ItemSubGroupMasterModelDropdown
    {
        public int ItemSubGroupID { get; set; }
        public string ItemSubGroupText { get; set; }
    }

    public class MachineOperatingStatusMasterModelDropdown
    {
        public int MachineOperatingStatusID { get; set; }
        public string MachineOperatingStatusText { get; set; }
    }
    public class MachineCategoryMasterModelDropdown
    {
        public int MachineCategoryID { get; set; }
        public string MachineCategoryName { get; set; }
    }
    
    public class MachineryMasterModelDropdown
    {
        public int MachineryID { get; set; }
        public string MachineryName { get; set; }
    }
 
 	 
 public class DepreciationMethodMasterModelDropdown
    {
        public int DepreciationMethodID { get; set; }
        public string MethodName { get; set; }
    }
 
 	 
 public class UtilityMasterModelDropdown
    {
        public int UtilityID { get; set; }
        public string UtilityName { get; set; }
    }
    public class ShiftMasterModelDropdown
    {
        public int ShiftID { get; set;}
        public string ShiftName { get; set; }
    }
    public class ItemMasterModelDropdown
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
    }
 
    public class ReportMasterModelDropdown
    {
        public int ReportID { get; set; }
        public string ReportName { get; set; }
    }
 
 	 
 public class FormMasterModelDropdown
    {
        public int FormID { get; set; }
        public string FormName { get; set; }
    }
    public class SAPItemModelDropdown
    {
        public string FinishGoodName { get; set; }
        public string ItemCode { get; set; }
    }
    
 public class AddressTypeMasterModelDropdown
    {
        public int AddressTypeID { get; set; }
        public string AddressTypeName { get; set; }
    }

    public class SalaryFormulaTypeMasterDropdown
    {
        public int SalaryFormulaTypeID { get; set; }
        public string SalaryFormulaTypeText { get; set; }
    }

    public class DatabaseTables
    {
        public string TableName { get; set;}
        public string Object_ID { get; set; }
    }
    public class DatabaseTableColumns
    {
        public string Column_Name { get; set; }
        public string Data_Type { get; set; }
        public string Is_Nullable { get; set; }
        public string Column_Default { get; set; }
    }
    
 public class LocationMasterModelDropdown
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }
 
 	 
 public class TermTypeMasterModelDropdown
    {
        public int TermTypeID { get; set; }
        public string TermTypeText { get; set; }
    }
public class TermsMasterModelDropdown
    {
        public int TermsID { get; set; }
        public string TermText { get; set; }
    }
 
 	 //$AddCommonMasterModel$

}

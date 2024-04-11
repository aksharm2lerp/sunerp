namespace Business.Entities.Master.UserPermissionMasterModel
{
    public class UserPermissionMaster
    {
        public int UserPermissionID { get; set; }
        public string UserPermissionText { get; set; }
        public int UserID { get; set; }
        public int PackageID { get; set; }
        public int FormID { get; set; }
        public string FormName { get; set; }
        public bool Assign { get; set; }
        public bool Readonly { get; set; }
        public bool Print { get; set; }
        public bool ExportToExcel { get; set; }
        public bool ExportToPDF { get; set; }
        public object SrNo { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public bool Edit { get; set; }
        public bool View { get; set; }
    }
}

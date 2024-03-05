namespace Business.Entities.FormMasterEntitie
{
    public class FormMaster
    {
        public object SrNo { get; set; }
        public int FormID { get; set; }
        public string FormName { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsActive { get; set; } = true;
        public int FormTypeID { get; set; }
        public string FormTypeText { get; set; }
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public int CreatedOrModifiedBy { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int ParentMenuID { get; set; }
        public string ParentMenuName { get; set; }
        public int IconMasterID { get; set; }
        public string IconName { get; set; }
        public string IconHTMLTag { get; set; }



    }
}

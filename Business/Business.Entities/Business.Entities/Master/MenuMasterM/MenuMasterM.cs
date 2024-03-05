using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities.Master.MenuMasterM
{
    public class MenuMasterM
    {
        //public int ID { get; set; }
        //public string Name { get; set; }
        //public int MainMenuID { get; set; }
        //public string MainMenuName { get; set; }
        //public int MenuID { get; set; }
        //public string MenuName { get; set; }
        //public int FormNameID { get; set; }       
        //public string FormName { get; set; }        
        //public int AreaID { get; set; }
        //public string AreaName { get; set; }
        //public int ControllerID { get; set; }
        //public string ControllerName { get; set; }
        //public int ActionID { get; set; }
        //public string ActionName { get; set; }

        public int FormID { get; set; }
        public string FormName { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int ParentMenuID { get; set; }
        public string ParentMenuName { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int SubMenuID { get; set; }
        public string SubMenuName { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public object SrNo { get; set; }
        public string FormIcon { get; set; }
        public string MenuIcon { get; set; }

    }
    public class ParentMenuM
    {
        public int ParentMenuID { get; set; }
        public string ParentMenuName { get; set; }
        public string PMenuIcon { get; set; }
    }

}

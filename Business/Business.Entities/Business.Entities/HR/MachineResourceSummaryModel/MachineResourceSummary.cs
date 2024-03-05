using System;
using System.Collections.Generic;

namespace Business.Entities.HR.MachineResourceSummaryModel
{
    public class MachineResourceSummary
    {
        public int SrNo { get; set; }


        public int MachineResourceSummaryID { get; set; }
        public string MachineResourceSummaryText { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
        public int ShiftID { get; set; }        
        public int DepartmentID { get; set; }
        public string MachineryName { get; set; }
        public int MachineryID { get; set; }
        public int Operators { get; set; }
        public int Helpers { get; set; }

        public int TotalOperator { get; set; }
        public int CurrentPresentOperator { get; set; }
        public int AbsentOperator { get; set; }
        public int TotalHelper { get; set; }
        public int CurrentPresentHelper { get; set; }
        public int AbsentHelper { get; set; }
        public int RequiredOperator { get; set; }
        public int RequiredHelper { get; set; }


        public List<EmployeeDetails> EmployeeDetails { get; set; }

        


        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}

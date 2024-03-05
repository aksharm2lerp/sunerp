using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineryMaintenanceTxnModel
{
public class MachineryMaintenanceTxn  
{ 
 public int SrNo { get; set; }    
    public int MachineryMaintenanceID { get; set; }  
    public string ItemCode { get; set; }  
    public int? MachineryID { get; set; }  
    public string MachineryName { get; set; }
    public string DefectDescription { get; set; }  
    public string Troubleshoot { get; set; }  
    public DateTime ActionTakenTime { get; set; } = DateTime.Today;
    public DateTime ActionTakenDate { get; set; } = DateTime.Today;
    public string ActionTakenBy { get; set; }  
    public decimal? RepairingCharges { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
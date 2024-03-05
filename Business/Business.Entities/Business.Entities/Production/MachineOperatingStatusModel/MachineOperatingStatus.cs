using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.MachineOperatingStatusModel
{
public class MachineOperatingStatus  
{ 
 public int SrNo { get; set; }    
    public int MachineOperatingStatusID { get; set; }  
    public string MachineOperatingStatusText { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
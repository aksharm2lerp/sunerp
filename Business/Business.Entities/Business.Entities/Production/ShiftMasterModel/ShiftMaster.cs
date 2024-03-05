using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.ShiftMasterModel
{
public class ShiftMaster  
{ 
 public int SrNo { get; set; }    
    public int ShiftID { get; set; }  
    public string ShiftName { get; set; }  
    public DateTime? StartTime { get; set; }  
    public DateTime? EndTime { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
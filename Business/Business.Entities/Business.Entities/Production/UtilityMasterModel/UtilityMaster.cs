using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Production.UtilityMasterModel
{
public class UtilityMaster  
{ 
 public int SrNo { get; set; }    
    public int UtilityID { get; set; }  
    public string UtilityName { get; set; }  
    public string Notes { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
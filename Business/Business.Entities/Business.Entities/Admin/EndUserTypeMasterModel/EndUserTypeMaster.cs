using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Admin.EndUserTypeMasterModel
{
public class EndUserTypeMaster  
{ 
 public int SrNo { get; set; }    
    public int EndUserTypeMasterID { get; set; }  
    public string EndUserTypeText { get; set; }  
    public string EndUserTypeTableName { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
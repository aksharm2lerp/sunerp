using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Marketing.RequestForQuotTypeMasterModel
{
public class RequestForQuotTypeMaster  
{ 
 public int SrNo { get; set; }    
    public int RequestForQuotTypeID { get; set; }  
    public string RequestForQuotTypeText { get; set; }  
    public string Remark { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
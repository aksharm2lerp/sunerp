using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.SalesDistribution.TermTypeMasterModel
{
public class TermTypeMaster  
{ 
 public int SrNo { get; set; }    
    public int TermTypeID { get; set; }  
    public string TermTypeText { get; set; }  
    public string Note { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
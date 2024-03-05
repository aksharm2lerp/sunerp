using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.HR.TestHTMLForm2Model
{
public class TestHTMLForm2  
{ 
 public int SrNo { get; set; }    
    public int TestHTMLForm2ID { get; set; }  
    public string TestHTMLForm2Name { get; set; }  
    public int? AddressID { get; set; }  
    public int? RoleID { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
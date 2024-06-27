using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.Marketing.TaxFormulaMasterModel
{
public class TaxFormulaMaster  
{ 
 public int SrNo { get; set; }    
    public int TaxFormulaID { get; set; }  
    public int CustomerID { get; set; }  
    public string CustomerName { get; set; }  
    public int FormulaTypeID { get; set; }  
    public string FormulaHead { get; set; }  
    public string FormulaLabel { get; set; }  
    public string Formula { get; set; }  
    public decimal? FormulaPercentage { get; set; }  
    public decimal? FormulaValue { get; set; }  
    public bool IsActive { get; set; } = true;  
    public int CreatedBy { get; set; }  
    public DateTime CreatedDate { get; set; }  
    public int? ModifiedBy { get; set; }  
    public DateTime? ModifiedDate { get; set; } public int CreatedOrModifiedBy { get; set; } 
							}
}
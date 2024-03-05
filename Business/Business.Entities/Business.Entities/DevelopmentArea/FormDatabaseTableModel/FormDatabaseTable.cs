using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entities.DevelopmentArea.FormDatabaseTableModel
{
    public class FormDatabaseTable
    {
        public int SrNo { get; set; }
        public int FormDatabaseTableID { get; set; }
        public string TableName { get; set; }
        public string Object_ID { get; set; }
        public string Remark { get; set; }
        public int? FormID { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedOrModifiedBy { get; set; }
    }
}
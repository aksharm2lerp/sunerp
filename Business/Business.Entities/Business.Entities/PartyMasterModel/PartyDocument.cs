using Microsoft.AspNetCore.Http;
using System;

namespace Business.Entities.Party
{
    public class PartyDocument
    {
        public int SrNo { get; set; }
        public int PartyDocumentID { get; set; }
        public int PartyID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentExtension { get; set; }
        public int DocumentTypeID { get; set; }
        public string DocumentPath { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedOrModifiedBy { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}

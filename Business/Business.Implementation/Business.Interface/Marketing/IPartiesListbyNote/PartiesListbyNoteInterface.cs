using Business.Entities.PartyMasterModel;
using Business.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Marketing.IPartiesListbyNote
{
    public interface PartiesListbyNoteInterface
    {   
        Task<PagedDataTable<PartyMaster>> GetAllNotificationTest(int UserID = 0, int PartyID = 0, int PositiveNoteID = 0);
    }
}

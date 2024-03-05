using Business.Entities.HR.TestHTMLForm2Model;
using Business.SQL;
using System.Threading.Tasks;

namespace Business.Interface.HR.ITestHTMLForm2
{
    public interface TestHTMLForm2Interface
    {        
        Task<PagedDataTable<TestHTMLForm2>> GetAllTestHTMLForm2Async(int pageNo, int pageSize, string searchString = "", string orderBy = "TestHTMLForm2ID", string sortBy = "ASC");

        Task<TestHTMLForm2> GetTestHTMLForm2Async(int TestHTMLForm2ID);

        Task<int> AddOrUpdateTestHTMLForm2(TestHTMLForm2 model);

    }
}

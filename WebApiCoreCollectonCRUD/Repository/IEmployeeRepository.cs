using WebApiCoreCollectonCRUD.Models;

namespace WebApiCoreCollectonCRUD.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAll();
        EmployeeModel GetById(int id);
        IEnumerable<EmployeeModel> GetByDept(string dept);
        void Add(EmployeeModel employee);
        void Update(int id, EmployeeModel employee);
        void UpdateEmail(int id, string email);
        void Delete(int id);
    }
}

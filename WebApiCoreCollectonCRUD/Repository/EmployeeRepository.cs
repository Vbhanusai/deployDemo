using WebApiCoreCollectonCRUD.Models;

namespace WebApiCoreCollectonCRUD.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<EmployeeModel> _empList = new List<EmployeeModel>()
        {
            new EmployeeModel(){ Id=101, Name="Bhanu", Department="Software", MobileNo=9988776655, Email="bhanu@gmail.com"},
            new EmployeeModel(){ Id=102, Name="Arun", Department="HR", MobileNo=8877665544, Email="Arun@gmail.com"},
            new EmployeeModel(){ Id=103, Name="Hari", Department="Software", MobileNo=7766554433, Email="Hari@gmail.com"}
        };
        public IEnumerable<EmployeeModel> GetAll()
        {
            return _empList;
        }
        public EmployeeModel GetById(int id)
        {
            return _empList.FirstOrDefault(e => e.Id==id);
        }
        public IEnumerable<EmployeeModel> GetByDept(string dept)
        {
            return _empList.Where(e => e.Department.Equals(dept, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(EmployeeModel emp)
        {
            _empList.Add(emp);
        }
        public void Update(int id, EmployeeModel emp)
        {
            var Oldemp = _empList.FirstOrDefault(e => e.Id==id);
            if(Oldemp != null)
            {
                Oldemp.Name = emp.Name;
                Oldemp.Department = emp.Department;
                Oldemp.MobileNo = emp.MobileNo;
                Oldemp.Email = emp.Email;
            }
        }

        public void UpdateEmail(int id, string email)
        {
            var Oldemp = _empList.FirstOrDefault(e => e.Id == id);
            if (Oldemp != null)
            {
                Oldemp.Email = email;
            }
        }

        public void Delete(int id)
        {
            var emp = _empList.FirstOrDefault(e => e.Id == id);
            if(emp != null)
            {
                _empList.Remove(emp);
            }
        }



    }
}

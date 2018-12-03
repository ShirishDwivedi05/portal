using Porta.DataAccess;
using Porta.DataAccess.Common;
using Porta.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BusinessApplicationLayer
{
    public class EmployeeService : IGenericPattern<Employee>
    {
        private PortalContext context = new PortalContext();
        private GenericPattern<Employee> empRepository;
        public Employee Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> ExecuteProcQuery(int empId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> ExecuteQuery()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FindBy(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(object id)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}

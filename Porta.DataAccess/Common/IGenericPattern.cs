namespace Porta.DataAccess.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Portal.MetaData.Models;

    public interface IGenericPattern<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        int Create(T entity);

        int Update(T entity);

        int Delete(T entity);

        T GetById(object id);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        IEnumerable<T> ExecuteQuery();

        IEnumerable<T> ExecuteProcQuery(int empId);
    }
}

namespace Porta.DataAccess.Common
{
    using System.Collections.Generic;

    public interface IUnitofWork<T>
        where T : class
    {
        IEnumerable<T> ExecuteProc(int empId);
    }
}

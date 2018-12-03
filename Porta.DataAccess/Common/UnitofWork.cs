namespace Porta.DataAccess.Common
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;

    public class UnitofWork<T> : IUnitofWork<T>
        where T : class
    {
        private PortalContext dbContext;
        private DbSet<T> dbSet;

        public UnitofWork(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            this.dbSet = this.DbContext.Set<T>();
        }

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected PortalContext DbContext
        {
            get { return this.dbContext ?? (this.dbContext = this.DbFactory.Init()); }
        }

        public IEnumerable<T> ExecuteProc(int esdProjectId)
        {
            SqlParameter objParam = new SqlParameter("@empId", esdProjectId);
            var result = this.dbContext.Database.SqlQuery<T>("usp_GetEmployee @empId", objParam);
            return result;
        }
    }
}

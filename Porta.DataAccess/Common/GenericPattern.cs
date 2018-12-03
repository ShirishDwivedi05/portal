namespace Porta.DataAccess.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Linq.Expressions;
    using Portal.MetaData.Models;

    public class GenericPattern<T> : IGenericPattern<T>
        where T : class
    {
        private PortalContext dbContext;
        private DbSet<T> dbSet;

        public GenericPattern(IDbFactory dbFactory)
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

        public virtual IEnumerable<T> GetAll()
        {
            // this.DbContext.Database.Log = Logger.Log;
            return this.DbContext.Set<T>();
        }

        public virtual int Create(T entity)
        {
            try
            {
                this.DbContext.Entry(entity).State = System.Data.Entity.EntityState.Added;
                int returnValue = this.DbContext.SaveChanges();
                return returnValue;
            }
            catch (DbUpdateException objEx)
            {
                throw objEx;
            }
        }

        public virtual int Update(T entity)
        {
            try
            {
                this.DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                int returnValue = this.DbContext.SaveChanges();
                return returnValue;
            }
            catch (DbUpdateException objEx)
            {
                throw objEx;
            }
        }

        public virtual T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual int Delete(T entity)
        {
            try
            {
                this.DbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                int returnValue = this.DbContext.SaveChanges();
                return returnValue;
            }
            catch (DbUpdateException objEx)
            {
                throw objEx;
            }
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.DbContext.Set<T>().Where(predicate);
        }

        public virtual T Add(T entity)
        {
            var result = this.dbSet.Add(entity);
            this.Save();
            return result;
        }

        public virtual void Save()
        {
            try
            {
                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }

        public virtual IEnumerable<T> ExecuteQuery()
        {
            return this.DbContext.Database.SqlQuery<T>("Select * From Employee");
        }

        public virtual IEnumerable<T> ExecuteProcQuery(int empId)
        {
            return this.DbContext.Database.SqlQuery<T>("Exec usp_GetEmployee " + empId);
        } 
    }
}

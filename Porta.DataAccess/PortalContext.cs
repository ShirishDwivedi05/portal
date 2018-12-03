namespace Porta.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataAccess.Domain;
    using System.Data.Entity.Infrastructure;

    public partial class PortalContext : DbContext
    {
        public PortalContext()
            : base("name=PortalContext")
        {
            this.SetCommandTimeOut(360);
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public void SetCommandTimeOut(int timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = timeout;
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

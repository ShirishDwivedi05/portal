using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porta.DataAccess.Common
{
    public class DbFactory : IDbFactory
    {
        PortalContext dbContext;
        public PortalContext Init()
        {
            return dbContext ?? (dbContext = new PortalContext());
        }
    }
}

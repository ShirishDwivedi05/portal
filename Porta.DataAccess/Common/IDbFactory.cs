using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porta.DataAccess.Common
{
    public interface IDbFactory
    {
        PortalContext Init();
    }
}

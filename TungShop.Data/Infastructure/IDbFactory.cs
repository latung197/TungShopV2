using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TungShop.Data.Infastructure
{
    public interface IDbFactory
    {
        TungShopDbContext Init();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TungShop.Data.Infastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private TungShopDbContext dbContext;
        public TungShopDbContext Init()
        {
            return dbContext ?? (dbContext = new TungShopDbContext());

        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }

}

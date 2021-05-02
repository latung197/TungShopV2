using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TungShop.Data.Infastructure
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly IDbFactory dbFactory;
        private TungShopDbContext dbContext;

        public UnitOfwork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public TungShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}


using PaymentOrderModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrderData
{
    public class PaymentOrderDbContext : DbContext, IDbContext
    {
        public PaymentOrderDbContext() : base("PaymentDetailsEntities")
        {

        }
        public DbSet<PaymentOrder> PaymentOrder { get; set; }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
using PaymentOrderData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrderData
{
    public class PaymentOrderDataRepo<T> : IPaymentOrderData<T> where T : class
    {
        private readonly PaymentOrderDbContext _db;
        private IDbSet<T> _entities;
        public PaymentOrderDataRepo(PaymentOrderDbContext db)
        {
            _db = db;
        }
        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _db.Set<T>();
                }
                return _entities;
            }
        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();

        }
        public void Remove(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();

        }
        public T Get(int Id)
        {
            return _db.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entities;
        }

        public void Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
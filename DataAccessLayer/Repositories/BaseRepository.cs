using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        protected ECommerceDb _context;
        public BaseRepository(ECommerceDb context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> match=null)
        {
            if (match == null)
                return _context.Set<T>().ToList();
            else
                return _context.Set<T>().Where(match).ToList();
        }

        public virtual T Add(T t)
        {
            _context.Set<T>().Add(t);
            //_context.SaveChanges();
            return t;
        }

        public virtual T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual T Update(T t, int id)
        {
            if (t == null)
                return null;

            T exist = _context.Set<T>().Find(id);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                //_context.SaveChanges();
            }
            return exist;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

    public interface IGenericRepository<T>
    {
        IEnumerable<T> Select(Expression<Func<T, bool>> match = null);
        T Add(T t);
        T Update(T t, int id);
        T FindById(int id);
        void Save();
    }
}

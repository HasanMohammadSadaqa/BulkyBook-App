using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();                                          //this is a method to retrieve all "T" objects 
        T GetOneElement(Expression<Func<T, bool>> filter);                // this is a method to retrieve one "T" object >>>>>> there is 3 methods to do that, 1) Find(primary key), 2) FirstOrDefault(link operation), 3) where (link operation).FirstOrDefault >>>>> Here we use First or default and this is the general syntax for that 
        void AddOneElement(T entity);                                     // this is a method to add an object to database
        void RemoveOneElement(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

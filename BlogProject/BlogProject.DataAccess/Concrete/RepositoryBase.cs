using BlogProject.DataAccess.Abstract;
using BlogProject.Entities.Context;
using BlogProject.Entities.Entities.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccess.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        private readonly SqlDbContext _db;
        public RepositoryBase(SqlDbContext db)
        {
            _db = db;
        }
        public DbSet<T> Table => _db.Set<T>();

        public bool Add(T entity)
        {
            EntityEntry<T> entityEntry =  Table.Add(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Remove(int id)
        {
            T model = Table.Find(id);
            return Remove(model);
        }
        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter = null)
         => filter == null
            ?  Table.ToList()
            :  Table.Where(filter).ToList();

        public T GetById(int id)
            =>  Table.Find(id);


        public  T GetFirst(Expression<Func<T, bool>> filter = null)
        =>  Table.Where(filter).FirstOrDefault();


        public  int Save()
        =>  _db.SaveChanges();

    }
}

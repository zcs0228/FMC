using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMC.EFDbModels;
using System.Data.Entity;

namespace FMC.EFRepository
{
    public abstract class BaseRepository
    {
        public BaseRepository()
        {
            dbContext = GetDbContext();
        }

        protected FMSDbContext dbContext { get; set; }
        protected FMSDbContext GetDbContext()
        {
            if((FMSDbContext)HttpContext.Current.Session["FMSDbContext"] == null)
            {
                dbContext = new FMSDbContext();
                HttpContext.Current.Session["FMSDbContext"] = dbContext;
            }
            else
            {
                dbContext = (FMSDbContext)HttpContext.Current.Session["FMSDbContext"];
            }
            return dbContext;
        }

        protected T GetLocalData<T>(Guid Id) where T : class, IEntity
        {
            //FMSDbContext context = GetDbContext();
            T t = dbContext.Set<T>().Local.Where(x => x.Id == Id).FirstOrDefault();
            if (t == null)
            {
                t = dbContext.Set<T>().Where(x => x.Id == Id).FirstOrDefault();
            }
            return t;
        }

        protected IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class, IEntity
        {
            return dbContext.Set<T>().SqlQuery(sql, parameters);
        }

        protected T Attach<T>(Guid Id) where T : class, IEntity, new()
        {
            //FMSDbContext context = GetDbContext();
            T t = dbContext.Set<T>().Local.Where(x => x.Id == Id).FirstOrDefault();
            if (t == null)
            {
                t = new T { Id = Id };
                dbContext.Set<T>().Attach(t);
            }
            return t;
        }

        protected FMSDbContext BaseEdit<T>(T entity, EntityState state) where T : class, IEntity
        {
            T temp = dbContext.Set<T>().Local.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (temp != null)
            {
                dbContext.Entry<T>(temp).State = EntityState.Detached;
            }
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry<T>(entity).State = state;

            return dbContext;
        }

        protected FMSDbContext EntityAttach<T>(T entity) where T : class, IEntity
        {
            //FMSDbContext context = GetDbContext();
            T temp = dbContext.Set<T>().Local.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (temp != null)
            {
                dbContext.Entry<T>(temp).State = EntityState.Detached;
            }
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry<T>(entity).State = EntityState.Modified;

            return dbContext;
        }
    }
}
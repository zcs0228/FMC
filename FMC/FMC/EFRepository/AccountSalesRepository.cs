using FMC.EFDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FMC.EFRepository
{
    public class AccountSalesRepository : BaseRepository, IRepository<AccountSales>
    {
        //private FMSDbContext _dbContext;
        public AccountSalesRepository()
        {
            //_dbContext = base.GetDbContext();
        }

        public void Create(AccountSales entity)
        {
            //ProductionCategory temp = base.GetLocalData<ProductionCategory>(entity.ProductionCategory.Id);
            //entity.ProductionCategory = temp;
            dbContext.AccountSales.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(AccountSales entity)
        {
            this.BaseEdit<AccountSales>(entity, EntityState.Deleted).SaveChanges();
        }

        public IEnumerable<AccountSales> FindAll()
        {
            DateTime start = DateTime.Now.AddYears(-1);
            DateTime end = DateTime.Now;
            //使用Include的泛型方法，需要引进System.Data.Entity命名空间
            return dbContext.AccountSales.Include(t => t.ProductionCategory)
                .Where(t => (t.SalesDate > start && t.SalesDate <= end)).ToList();
            //return _dbContext.AccountSales.Include("ProductionCategory").ToList();
        }

        public AccountSales Read(Guid id)
        {
            return dbContext.AccountSales.FirstOrDefault(T => T.Id == id);
        }

        public void Update(AccountSales entity)
        {
            base.EntityAttach<AccountSales>(entity).SaveChanges();
        }
    }
}
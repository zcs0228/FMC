using FMC.EFDbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FMC.EFRepository
{
    public class ProductionCategoryRepository : BaseRepository, IRepository<ProductionCategory>
    {
        //private FMSDbContext _dbContext;
        public ProductionCategoryRepository()
        {
            //_dbContext = base.GetDbContext();
        }

        public void Create(ProductionCategory entity)
        {
            dbContext.ProductionCategorys.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(ProductionCategory entity)
        {
            this.BaseEdit<ProductionCategory>(entity, EntityState.Deleted).SaveChanges();
        }

        public IEnumerable<ProductionCategory> FindAll()
        {
            return dbContext.ProductionCategorys.Where(t => t.DeleteMark == false).ToList();
        }

        public ProductionCategory Read(Guid id)
        {
            return dbContext.ProductionCategorys.FirstOrDefault(T => T.Id == id);
        }

        public void Update(ProductionCategory entity)
        {
            base.EntityAttach<ProductionCategory>(entity).SaveChanges();
        }
    }
}
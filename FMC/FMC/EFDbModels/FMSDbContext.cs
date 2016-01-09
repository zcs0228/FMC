using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FMC.EFDbModels
{
    public class FMSDbContext : DbContext
    {
        public FMSDbContext()
            : base("DefaultConnection")
        { }

        public DbSet<ProductionCategory> ProductionCategorys { get; set; }

        public DbSet<AccountSales> AccountSales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProductionCategoryConfiguration());
            modelBuilder.Configurations.Add(new AccountSalesConfiguration());

            base.OnModelCreating(modelBuilder);

            #region 设置Id字段由数据库自动生成

            //modelBuilder.Entity<ProductionCategory>().Property(t => t.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<AccountSales>().Property(t => t.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            #endregion

            #region 设置字符串类型为varchar

            //modelBuilder.Entity<ProductionCategory>().Property(t => t.Name).IsUnicode(false);
            //modelBuilder.Entity<ProductionCategory>().Property(t => t.Unit).IsUnicode(false);
            //modelBuilder.Entity<ProductionCategory>().Property(t => t.Code).IsUnicode(false);

            #endregion
        }
    }

    public class ProductionCategoryConfiguration : EntityTypeConfiguration<ProductionCategory>
    {
        public ProductionCategoryConfiguration()
        {
            //设置主键值由数据库自动生成
            HasKey(t => t.Id).Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Property(t => t.CName).IsRequired().HasMaxLength(50);

            Property(t => t.Name).IsUnicode(false);
            Property(t => t.Unit).IsUnicode(false);
            Property(t => t.Code).IsUnicode(false);
        }
    }

    public class AccountSalesConfiguration : EntityTypeConfiguration<AccountSales>
    {
        public AccountSalesConfiguration()
        {
            HasKey(t => t.Id).Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //绑定外键
            HasRequired(t => t.ProductionCategory).WithMany(t => t.AccountSales).HasForeignKey(t => t.ProductionCategoryId);
        }
    }
}
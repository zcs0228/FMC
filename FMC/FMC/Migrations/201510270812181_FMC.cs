namespace FMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FMC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountSales",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesDate = c.DateTime(),
                        ProductionCategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductionCategory", t => t.ProductionCategoryId, cascadeDelete: true)
                .Index(t => t.ProductionCategoryId);

            //设置Id字段的数据库自动生成方式
            AlterColumn("dbo.AccountSales", "Id", c => c.Guid(nullable: false, defaultValueSql: "newsequentialid()"));

            CreateTable(
                "dbo.ProductionCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Code = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        Unit = c.String(unicode: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Profit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(),
                        DeleteMark = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            //设置Id字段的数据库自动生成方式
            AlterColumn("dbo.ProductionCategory", "Id", c => c.Guid(nullable: false, defaultValueSql: "newsequentialid()"));

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountSales", "ProductionCategoryId", "dbo.ProductionCategory");
            DropIndex("dbo.AccountSales", new[] { "ProductionCategoryId" });
            DropTable("dbo.ProductionCategory");
            DropTable("dbo.AccountSales");
        }
    }
}

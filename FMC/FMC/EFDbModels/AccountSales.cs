using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMC.EFDbModels
{
    public class AccountSales : BaseEntity
    {
        public decimal Quantity { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalProfit { get; set; }

        public DateTime? SalesDate { get; set; }

        public Guid ProductionCategoryId { get; set; }
        public virtual ProductionCategory ProductionCategory { get; set; }
    }
}
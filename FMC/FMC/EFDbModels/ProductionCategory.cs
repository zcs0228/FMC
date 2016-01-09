using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMC.EFDbModels
{
    public class ProductionCategory : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public decimal Cost { get; set; }

        public decimal Profit { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool DeleteMark { get; set; }

        public virtual List<AccountSales> AccountSales { get; set; }
    }
}
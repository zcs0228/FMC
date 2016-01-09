using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMC.Models.AccountSales
{
    public class EditAccountSales
    {
        public string Id { get; set; }

        public string Quantity { get; set; }

        public string TotalCost { get; set; }

        public string TotalProfit { get; set; }

        public string SalesDate { get; set; }

        public string ProductionCategoryId { get; set; }

        public string ProductionCategoryCode { get; set; }

        public string ProductionCategoryName { get; set; }

        public string ProductionCategoryUnit { get; set; }
    }
}
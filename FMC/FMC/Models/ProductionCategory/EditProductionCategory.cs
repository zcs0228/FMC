using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMC.Models.ProductionCategory
{
    public class EditProductionCategory
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public string Cost { get; set; }

        public string Profit { get; set; }

        public string CreateDate { get; set; }

        public bool DeleteMark { get; set; }
    }
}
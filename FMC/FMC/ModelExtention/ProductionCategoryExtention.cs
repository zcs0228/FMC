using FMC.EFDbModels;
using FMC.Models.ProductionCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMC.ModelExtention
{
    public static class ProductionCategoryExtention
    {
        public static ProductionCategory EditProductionCategoryToEF(this EditProductionCategory model)
        {
            ProductionCategory result = new ProductionCategory();
            if (model.Id != null)
            {
                result.Id = new Guid(model.Id);
            }
            result.Code = model.Code;
            result.Name = model.Name;
            result.Unit = model.Unit;

            decimal costtemp = 0m;
            Decimal.TryParse(model.Cost, out costtemp);
            result.Cost = costtemp;

            decimal profittemp = 0m;
            Decimal.TryParse(model.Profit, out profittemp);
            result.Profit = profittemp;

            if (model.CreateDate != "")
            {
                result.CreateDate = DateTime.Parse(model.CreateDate);
            }

            result.DeleteMark = model.DeleteMark;

            return result;
        }

        public static EditProductionCategory EFToEditProductionCategory(this ProductionCategory model)
        {
            EditProductionCategory result = new EditProductionCategory();
            result.Id = model.Id.ToString();
            result.Code = model.Code;
            result.Name = model.Name;
            result.Unit = model.Unit;
            result.Cost = model.Cost.ToString();
            result.Profit = model.Profit.ToString();
            result.CreateDate = model.CreateDate.ToString();
            result.DeleteMark = model.DeleteMark;

            return result;
        }

        public static IEnumerable<EditProductionCategory> EFToEditProductionCategory(this IEnumerable<ProductionCategory> models)
        {
            IList<EditProductionCategory> results = new List<EditProductionCategory>();

            foreach (var item in models)
            {
                results.Add(item.EFToEditProductionCategory());
            }
            return results;
        }
    }
}
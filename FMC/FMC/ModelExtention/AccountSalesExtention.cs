using FMC.EFDbModels;
using FMC.Models.AccountSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMC.ModelExtention
{
    public static class AccountSalesExtention
    {
        public static AccountSales EditAccountSalesToEF(this EditAccountSales model)
        {
            AccountSales result = new AccountSales();

            if (model.Id != null)
            {
                result.Id = new Guid(model.Id);
            }

            decimal tmpQuantity = 0m;
            decimal.TryParse(model.Quantity, out tmpQuantity);
            result.Quantity = tmpQuantity;

            decimal tmpTotalCost = 0m;
            decimal.TryParse(model.TotalCost, out tmpTotalCost);
            result.TotalCost = tmpTotalCost;

            decimal tmpTotalProfit = 0m;
            decimal.TryParse(model.TotalProfit, out tmpTotalProfit);
            result.TotalProfit = tmpTotalProfit;

            if (model.SalesDate == null || model.SalesDate == "")
            {
                result.SalesDate = System.DateTime.Now;
            }
            else
            {
                result.SalesDate = DateTime.Parse(model.SalesDate);
            }

            if (model.ProductionCategoryId != null)
            {
                result.ProductionCategoryId = new Guid(model.ProductionCategoryId);
            }

            return result;
        }

        public static EditAccountSales EFToEditAccountSales(this AccountSales model)
        {
            EditAccountSales result = new EditAccountSales();

            result.Id = model.Id.ToString();
            result.Quantity = model.Quantity.ToString();
            result.TotalCost = model.TotalCost.ToString();
            result.TotalProfit = model.TotalProfit.ToString();
            result.SalesDate = model.SalesDate.ToString();
            result.ProductionCategoryId = model.ProductionCategory.Id.ToString();
            result.ProductionCategoryCode = model.ProductionCategory.Code;
            result.ProductionCategoryName = model.ProductionCategory.Name;
            result.ProductionCategoryUnit = model.ProductionCategory.Unit;

            return result;
        }

        public static IEnumerable<EditAccountSales> EFToAccountSaleses(this IEnumerable<AccountSales> models)
        {
            IList<EditAccountSales> results = new List<EditAccountSales>();

            foreach (var item in models)
            {
                results.Add(item.EFToEditAccountSales());
            }

            return results;
        }
    }
}
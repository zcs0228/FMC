using FMC.Models.AccountSales;
using FMC.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMC.Controllers
{
    public class AccountSalesController : Controller
    {
        private AccountSalesService _service;

        public AccountSalesController()
        {
            _service = new AccountSalesService();
        }

        // GET: AccountSales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public string Add(string productionId, string productionQuantity, string productionCost, string productionProfit)
        {
            string result = "";

            decimal tmpQuantity = 0m;
            decimal.TryParse(productionQuantity, out tmpQuantity);

            decimal tmpCost = 0m;
            decimal.TryParse(productionCost, out tmpCost);

            decimal tmpProfit = 0m;
            decimal.TryParse(productionProfit, out tmpProfit);

            decimal totalCost = tmpQuantity * tmpCost;
            decimal totalProfit = tmpQuantity * tmpProfit;

            EditAccountSales editModel = new EditAccountSales();
            editModel.Quantity = productionQuantity;
            editModel.TotalCost = totalCost.ToString();
            editModel.TotalProfit = totalProfit.ToString();
            editModel.ProductionCategoryId = productionId;

            result = _service.AddAccountSales(editModel).ToString();

            return result;
        }

        public string  Delete(string id)
        {
            EditAccountSales editModel = new EditAccountSales();
            editModel.Id = id;

            return _service.DeleteAccountSales(editModel).ToString();
        }

        public string GetDataList()
        {
            return _service.ListAccountSales();
        }
    }
}
using FMC.Models.ProductionCategory;
using FMC.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMC.Controllers
{
    public class ProductionCategoryController : BaseController
    {
        private ProductionCategoryService _service;

        public ProductionCategoryController()
        {
            _service = new ProductionCategoryService();
        }

        // GET: ProductionCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public string Add(string code, string name, string unit, string cost, string profit)
        {
            string result = "";

            EditProductionCategory editModel = new EditProductionCategory();
            editModel.Code = code;
            editModel.Name = name;
            editModel.Unit = unit;
            editModel.Cost = cost;
            editModel.Profit = profit;
            editModel.CreateDate = DateTime.Now.ToString();
            editModel.DeleteMark = false;

            result = _service.AddProductionCategory(editModel).ToString();

            return result;
        }

        public string GetDataList()
        {
            return _service.ListProductionCategory();
        }

        public string Delete(string id, string code, string name, string unit, string cost, string profit, string createDate)
        {
            string result = "";

            EditProductionCategory editModel = new EditProductionCategory();
            editModel.Id = id;
            editModel.Code = code;
            editModel.Name = name;
            editModel.Unit = unit;
            editModel.Cost = cost;
            editModel.Profit = profit;
            editModel.CreateDate = createDate;
            editModel.DeleteMark = true;

            result = _service.DeleteProductionCategory(editModel).ToString();

            return result;
        }
    }
}
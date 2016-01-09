using FMC.EFDbModels;
using FMC.EFRepository;
using FMC.ModelExtention;
using FMC.Models.ProductionCategory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMC.Serivces
{
    public class ProductionCategoryService
    {
        private ProductionCategoryRepository _repository;

        public ProductionCategoryService()
        {
            _repository = new ProductionCategoryRepository();
        }

        public int AddProductionCategory(EditProductionCategory model)
        {
            int result = 1;
            ProductionCategory EFModel = model.EditProductionCategoryToEF();
            try
            {
                _repository.Create(EFModel);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public string ListProductionCategory()
        {
            string result = "";

            IEnumerable<EditProductionCategory> models = _repository.FindAll().EFToEditProductionCategory();
            result = JsonConvert.SerializeObject(models);

            return result;
        }

        public int DeleteProductionCategory(EditProductionCategory model)
        {
            int result = 1;
            ProductionCategory efModel = model.EditProductionCategoryToEF();
            try
            {
                _repository.Update(efModel);
            }
            catch
            {
                result = 0;
            }
            return result;
        }
    }
}
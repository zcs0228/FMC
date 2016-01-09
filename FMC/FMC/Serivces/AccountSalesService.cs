using FMC.EFRepository;
using FMC.Models.AccountSales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMC.ModelExtention;
using Newtonsoft.Json;

namespace FMC.Serivces
{
    public class AccountSalesService
    {
        private AccountSalesRepository _repository;

        public AccountSalesService()
        {
            _repository = new AccountSalesRepository();
        }

        public int AddAccountSales(EditAccountSales model)
        {
            int result = 1;

            try
            {
                _repository.Create(model.EditAccountSalesToEF());
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public int DeleteAccountSales(EditAccountSales model)
        {
            int result = 1;

            try
            {
                _repository.Delete(model.EditAccountSalesToEF());
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public string ListAccountSales()
        {
            string result = "";

            IEnumerable<EditAccountSales> editModels = _repository.FindAll().EFToAccountSaleses();
            result = JsonConvert.SerializeObject(editModels);

            return result;
        }
    }
}
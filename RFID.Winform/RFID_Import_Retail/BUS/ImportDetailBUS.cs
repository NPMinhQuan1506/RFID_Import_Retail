using RFID_Import_Retail.DAO;
using RFID_Import_Retail.DTO;
using RFID_ImportDetail_Retail.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.BUS
{
    class ImportDetailBUS
    {
        Core.Common func = new Core.Common();
        private static ImportDetailBUS instance;
        public static ImportDetailBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImportDetailBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await loadDataById("");
        }

        public async Task<DataTable> loadDataById(string importId)
        {
            if(importId == "")
            {
                DataTable dtImport = new DataTable();
                DataTable dtProduct = new DataTable();
                dtImport = await ImportDetailDAO.Instance.loadData();
                dtProduct = await ProductDAO.Instance.loadData();
                var result = from import in dtImport.AsEnumerable()
                             join product in dtProduct.AsEnumerable() on import.Field<string>("ProductId") equals product.Field<string>("SKU")
                             select new
                             {
                                 ImportId = import.Field<string>("ImportId"),
                                 Product = product.Field<string>("Name"),
                                 ProductId = product.Field<string>("SKU"),
                                 Amount = Convert.ToInt32(import.Field<string>("Amount")),
                                 ImportPrice = Convert.ToDecimal(import.Field<string>("ImportPrice")),
                                 IsCheck = Convert.ToInt16(import.Field<string>("IsCheck"))
                             };
                DataTable dt = func.LinqQueryToDataTable(result);
                return dt;
            }
            else
            {
                DataTable dtImport = new DataTable();
                DataTable dtProduct = new DataTable();
                dtImport = await ImportDetailDAO.Instance.loadData();
                dtProduct = await ProductDAO.Instance.loadData();
                var result = from import in dtImport.AsEnumerable()
                             join product in dtProduct.AsEnumerable() on import.Field<string>("ProductId") equals product.Field<string>("SKU")
                             where import.Field<string>("ImportId") == importId
                             select new
                             {
                                 ImportId = import.Field<string>("ImportId"),
                                 Product = product.Field<string>("Name"),
                                 ProductId = product.Field<string>("SKU"),
                                 Amount = Convert.ToInt32(import.Field<string>("Amount")),
                                 ImportPrice = Convert.ToDecimal(import.Field<string>("ImportPrice")),
                                 IsCheck = Convert.ToInt16(import.Field<string>("IsCheck"))
                             };
                DataTable dt = func.LinqQueryToDataTable(result);
                return dt;
            }
        }

        public void create(string importId, string productId, int amount, decimal importPrice, int isCheck)
        {
            DateTime createdDate = DateTime.Now;
            DateTime modifiedDate = DateTime.MinValue;
            ImportDetailDTO product = new ImportDetailDTO(importId, productId, amount, importPrice, isCheck);
            ImportDetailDAO.Instance.create(product);
        }
    }
}

using DevExpress.XtraGrid;
using RFID_Import_Retail.DAO;
using RFID_Import_Retail.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.BUS
{
    class ProductBUS
    {
        private static ProductBUS instance;
        public static ProductBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await ProductDAO.Instance.loadData();
        }

        public async Task<DataTable> loadDataById(string SKU)
        {
            return await ProductDAO.Instance.loadDataById(SKU); 
        }

        public void create(string SKU, string name, string type, decimal price, int stockNumber, int minStockNumber, string unit, string description)
        {
            DateTime createdDate = DateTime.Now;
            DateTime modifiedDate = DateTime.MinValue;
            ProductDTO product = new ProductDTO(SKU, name, type, price, stockNumber, minStockNumber, unit, description, createdDate, modifiedDate, 1);
            ProductDAO.Instance.create(product);
        }

        public void update(string SKU, string name, string type, decimal price, int stockNumber, int minStockNumber, string unit, string description)
        {
            DateTime createdDate = DateTime.Now;
            DateTime modifiedDate = DateTime.MinValue;
            ProductDTO product = new ProductDTO(SKU, name, type, price, stockNumber, minStockNumber, unit, description, createdDate, modifiedDate, 1);
            ProductDAO.Instance.update(product);
        }

        public void delete(string SKU)
        {
            ProductDAO.Instance.delete(SKU);
        }

        public DataTable search(string search)
        {
            return null;
        }

        public DataTable searchByField(string search, string field)
        {
            return null;
        }
    }
}

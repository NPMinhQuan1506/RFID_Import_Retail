using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.DTO
{
    class ProductDTO
    {
        private static DataTable dt;
        public String SKU { set; get; } = "";
        public String name { set; get; } = "";
        public String type { set; get; } = "";
        public Decimal price { set; get; } = 0;
        public int stockNumber { set; get; } = 0;
        public int minStockNumber { set; get; } = 0;
        public String unit { set; get; } = "";
        public String description { set; get; } = "";
        public DateTime createdDate { set; get; } = DateTime.Now;
        public DateTime modifiedDate { set; get; } = DateTime.MinValue;
        public int isEnable { set; get; } = 1;

        public ProductDTO(string SKU, string name, string type, decimal price, int stockNumber, int minStockNumber, string unit, string description, DateTime createdDate, DateTime modifiedDate, int isEnable)
        {
            this.SKU = SKU;
            this.name = name;
            this.type = type;
            this.price = price;
            this.stockNumber = stockNumber;
            this.minStockNumber = minStockNumber;
            this.unit = unit;
            this.description = description;
            this.createdDate = createdDate;
            this.modifiedDate = modifiedDate;
            this.isEnable = isEnable;
        }

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["SKU"] = this.SKU;
            dr["Name"] = this.name;
            dr["Type"] = this.type;
            dr["Price"] = this.price;
            dr["StockNumber"] = this.stockNumber;
            dr["MinStockNumber"] = this.minStockNumber;
            dr["Unit"] = this.unit;
            dr["Description"] = this.description;
            dr["CreatedDate"] = this.createdDate;
            dr["ModifiedDate"] = this.modifiedDate;
            dr["IsEnable"] = this.isEnable;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("SKU");
            dt.Columns.Add("Name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Price");
            dt.Columns.Add("StockNumber");
            dt.Columns.Add("MinStockNumber");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Description");
            dt.Columns.Add("CreatedDate");
            dt.Columns.Add("ModifiedDate");
            dt.Columns.Add("IsEnable");
            return dt;
        }
    }
}

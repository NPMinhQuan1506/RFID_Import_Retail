using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.DTO
{
    class ImportDetailDTO
    {
        private static DataTable dt;
        public string importId { set; get; }
        public string productId { set; get; }
        public int amount { set; get; }
        public decimal importPrice { set; get; }
        public int isCheck { set; get; }

        public ImportDetailDTO(string importId, string productId, int amount, decimal importPrice, int isCheck)
        {
            this.importId = importId;
            this.productId = productId;
            this.amount = amount;
            this.importPrice = importPrice;
            this.isCheck = isCheck;
        }

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["ImportId"] = this.importId;
            dr["ProductId"] = this.productId;
            dr["Amount"] = this.amount;
            dr["ImportPrice"] = this.importPrice;
            dr["IsCheck"] = this.isCheck;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("ImportId");
            dt.Columns.Add("ProductId");
            dt.Columns.Add("Amount");
            dt.Columns.Add("ImportPrice");
            dt.Columns.Add("IsCheck");
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.DTO
{
    class ImportsDTO
    {
        private static DataTable dt;
        public string importId { set; get; } = "";
        public string empId { set; get; } = "";
        public int totalImport { set; get; } = 0;
        public int actualNumber { set; get; } = -1;
        public decimal totalPrice { set; get; } = 0;
        public string note { set; get; } = "";
        public DateTime createdDate { set; get; } = DateTime.Now;
        public DateTime modifiedDate { set; get; } = DateTime.MinValue;
        public int isEnable { set; get; } = 1;

        public ImportsDTO(string importId, string empId, int totalImport, int actualNumber, decimal totalPrice, string note, DateTime createdDate, DateTime modifiedDate, int isEnable)
        {
            this.importId = importId;
            this.empId = empId;
            this.totalImport = totalImport;
            this.actualNumber = actualNumber;
            this.totalPrice = totalPrice;
            this.note = note;
            this.createdDate = createdDate;
            this.modifiedDate = modifiedDate;
            this.isEnable = isEnable;
        }

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["ImportId"]=this.importId;
            dr["EmpId"] = this.empId;
            dr["TotalImport"]=this.totalImport;
            dr["ActualNumber"]=this.actualNumber;
            dr["TotalPrice"]=this.totalPrice;
            dr["Note"]=this.note;
            dr["CreatedDate"]=this.createdDate;
            dr["ModifiedDate"]=this.modifiedDate;
            dr["IsEnable"] = this.isEnable;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("ImportId");
            dt.Columns.Add("EmpId");
            dt.Columns.Add("TotalImport");
            dt.Columns.Add("ActualNumber");
            dt.Columns.Add("TotalPrice");
            dt.Columns.Add("Note");
            dt.Columns.Add("CreatedDate");
            dt.Columns.Add("ModifiedDate");
            dt.Columns.Add("IsEnable");
            return dt;
        }
    }
}

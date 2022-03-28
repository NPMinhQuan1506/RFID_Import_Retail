using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.DTO
{
    class EmployeeDTO
    {
        private static DataTable dt;
        public string empId { set; get; } = "";
        public string name { set; get; } = "";
        public string gender { set; get; } = "";
        public DateTime dateOfBirth { set; get; } = DateTime.MaxValue;
        public string department { set; get; } = "";

        public EmployeeDTO(string empId, string name, string gender, DateTime dateOfBirth, string department)
        {
            this.empId = empId;
            this.name = name;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.department = department;
        }

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["EmpId"] = this.empId;
            dr["Name"] = this.name;
            dr["Gender"] = this.gender;
            dr["DateOfBirth"] = this.dateOfBirth;
            dr["Department"] = this.department;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("EmpId");
            dt.Columns.Add("Name");
            dt.Columns.Add("Gender");
            dt.Columns.Add("DateOfBirth");
            dt.Columns.Add("Department");
            return dt;
        }
    }
}

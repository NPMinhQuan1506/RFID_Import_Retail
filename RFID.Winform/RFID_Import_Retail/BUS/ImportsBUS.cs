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
    class ImportsBUS
    {
        Core.Common func = new Core.Common();
        private static ImportsBUS instance;
        public static ImportsBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImportsBUS();
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
                DataTable dtEmployee = new DataTable();
                dtImport = await ImportsDAO.Instance.loadData();
                dtEmployee = await EmployeeDAO.Instance.loadData();
                var result = from import in dtImport.AsEnumerable()
                             join emp in dtEmployee.AsEnumerable() on import.Field<string>("EmpId") equals emp.Field<string>("EmpId")
                             select new
                             {
                                 ImportId = import.Field<string>("ImportId"),
                                 Employee = emp.Field<string>("Name"),
                                 TotalImport = Convert.ToInt32(import.Field<string>("TotalImport")),
                                 ActualNumber = Convert.ToInt32(import.Field<string>("ActualNumber")),
                                 TotalPrice = Convert.ToDecimal(import.Field<string>("TotalPrice")),
                                 Note = import.Field<string>("Note"),
                                 CreatedDate = func.StringToDateTime(import.Field<string>("CreatedDate")),
                                 ModifiedDate = func.StringToDateTime(import.Field<string>("ModifiedDate")),
                                 IsEnable = Convert.ToInt16(import.Field<string>("IsEnable"))
                             };
                DataTable dt = func.LinqQueryToDataTable(result);
                return dt;
            }
            return await ImportsDAO.Instance.loadDataById(importId);
        }

        public void create(string importId, string empId, int totalImport, int actualNumber, decimal totalPrice, string note)
        {
            DateTime createdDate = DateTime.Now;
            DateTime modifiedDate = DateTime.MinValue;
            ImportsDTO product = new ImportsDTO(importId, empId, totalImport, actualNumber, totalPrice, note, createdDate, modifiedDate, 1);
            ImportsDAO.Instance.create(product);
        }

        public void update(string importId, string empId, int totalImport, int actualNumber, decimal totalPrice, string note)
        {
            DateTime createdDate = DateTime.Now;
            DateTime modifiedDate = DateTime.MinValue;
            ImportsDTO product = new ImportsDTO(importId, empId, totalImport, actualNumber, totalPrice, note, createdDate, modifiedDate, 1);
            ImportsDAO.Instance.update(product);
        }

        public void delete(string importId)
        {
            ImportsDAO.Instance.delete(importId);
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

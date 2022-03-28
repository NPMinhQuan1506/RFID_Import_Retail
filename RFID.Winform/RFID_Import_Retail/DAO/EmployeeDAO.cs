using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using RFID_Import_Retail.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_Import_Retail.DAO
{
    class EmployeeDAO
    {
        IFirebaseClient Client;
        public EmployeeDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static EmployeeDAO instance;
        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Employee/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<DataTable> loadDataById(string EmpId)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Employee/" + EmpId + @"/");
            string resBody = "{\"" + EmpId + "\":" + res.Body.ToString() + "}";
            return populateData(resBody);
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, EmployeeDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = EmployeeDTO.convertToDataTable();

            foreach (var item in record)
            {
                DataRow dr = dt.NewRow();
                dr = item.Value.convertToDataRow();
                dt.Rows.Add(dr);
            }

            return dt;

        }

        public async void create(EmployeeDTO employee)
        {
            SetResponse response = await Client.SetTaskAsync(@"Employee/" + employee.empId, employee);
            EmployeeDTO result = response.ResultAs<EmployeeDTO>();
        }

        public async void update(EmployeeDTO employee)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Employee/" + employee.empId, employee);
            EmployeeDTO result = response.ResultAs<EmployeeDTO>();
        }

        public async void delete(string empId)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Employee/" + empId + @"/IsEnable/", 0);
            EmployeeDTO result = response.ResultAs<EmployeeDTO>();
        }
    }
}

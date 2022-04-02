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
    class ImportsDAO
    {
        IFirebaseClient Client;
        public ImportsDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static ImportsDAO instance;
        public static ImportsDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImportsDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Import/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<DataTable> loadDataById(string importId)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Import/" + importId + @"/");
            string resBody = "{\"" + importId + "\":" + res.Body.ToString() + "}";
            return populateData(resBody);
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, ImportsDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = ImportsDTO.convertToDataTable();

            foreach (var item in record)
            {
                DataRow dr = dt.NewRow();
                dr = item.Value.convertToDataRow();
                dt.Rows.Add(dr);
            }

            return dt;

        }

        public async void create(ImportsDTO import)
        {
            SetResponse response = await Client.SetTaskAsync(@"Import/" + import.importId, import);
        }

        public async void update(ImportsDTO import)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Import/" + import.importId, import);
        }

        public async void updateField(string importId, string field, dynamic value)
        {
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>()
            {
                { field,value }
            };
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Import/" + importId + @"/", data);
        }

        public async void delete(string importId)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Import/" + importId + @"/IsEnable/", 0);
            ImportsDTO result = response.ResultAs<ImportsDTO>();
        }
    }
}

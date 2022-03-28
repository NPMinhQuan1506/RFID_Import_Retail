using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using RFID_Import_Retail.DAO;
using RFID_Import_Retail.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_ImportDetail_Retail.DAO
{
    class ImportDetailDAO
    {
        IFirebaseClient Client;
        public ImportDetailDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static ImportDetailDAO instance;
        public static ImportDetailDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImportDetailDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"ImportDetail/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<DataTable> loadDataById(string importId)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"ImportDetail/" + importId + @"/");
            string resBody = "{\"" + importId + "\":" + res.Body.ToString() + "}";
            return populateData(resBody);
        }

        private DataTable populateData(string resBody)
        {
            var deserialized = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, ImportDetailDTO>>>(resBody);
            var record = deserialized.SelectMany(result => result.Value).ToList();
            DataTable dt = new DataTable();
            dt = ImportDetailDTO.convertToDataTable();

            foreach (var item in record)
            {
                DataRow dr = dt.NewRow();
                dr = item.Value.convertToDataRow();
                dt.Rows.Add(dr);
            }

            return dt;

        }

        public async void create(ImportDetailDTO importDetail)
        {
            SetResponse response = await Client.SetTaskAsync(@"ImportDetail/" + importDetail.importId + @"/"+ importDetail.productId, importDetail);
            //ImportDetailDTO result = response.ResultAs<ImportDetailDTO>();
        }
    }
}

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
    class ProductDAO
    {
        IFirebaseClient Client;
        public ProductDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Product/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<DataTable> loadDataById(string SKU)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Product/" + SKU + @"/");
            string resBody = "{\"" + SKU + "\":" + res.Body.ToString() + "}";
            return populateData(resBody); 
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, ProductDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = ProductDTO.convertToDataTable();

            foreach (var item in record)
            {
                DataRow dr = dt.NewRow();
                dr = item.Value.convertToDataRow();
                dt.Rows.Add(dr);
            }

            return dt;

        }

        public async void create(ProductDTO product)
        {
            SetResponse response = await Client.SetTaskAsync(@"Product/" + product.SKU, product);
            ProductDTO result = response.ResultAs<ProductDTO>();
        }

        public async void update(ProductDTO product)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Product/" + product.SKU, product);
            //ProductDTO result = response.ResultAs<ProductDTO>();
        }

        public async void delete(string SKU)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Product/" + SKU + @"/IsEnable/", 0);
            //ProductDTO result = response.ResultAs<ProductDTO>();
        }
    }
}

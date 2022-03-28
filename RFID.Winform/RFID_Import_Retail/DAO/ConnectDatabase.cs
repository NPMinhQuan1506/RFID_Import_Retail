using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace RFID_Import_Retail.DAO
{
    class ConnectDatabase
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "SwZ6RUGRfwW60uI98N3o4eBHtaUf9PbU8V4Sxkun",
            BasePath = "https://rfid-import-retail-180322-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;

        public ConnectDatabase()
        {
            Client = new FireSharp.FirebaseClient(config);
            if (Client != null)
            {
                Console.WriteLine("Connected Successfully");
            }
            else
            {
                Console.WriteLine("Error Connected! Please check your internet!");
            }
        }

        private static ConnectDatabase instance;
        public static ConnectDatabase Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnectDatabase();
                return instance;
            }
        }

        public IFirebaseClient getClient()
        {
            return this.Client;
        }
    }
}

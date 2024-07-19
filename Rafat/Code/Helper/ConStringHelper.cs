using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Code.Helper
{
    public static class ConStringHelper
    {


        public static void SetConString()
        {
            string server = Properties.Settings.Default.Server;
            string db = Properties.Settings.Default.DataBase;


            if (Properties.Settings.Default.ConType == "local")
            {
                Rafat.Data.ConString.ConStringValue = $"Server={server};Database={db};Encrypt=false;Trusted_Connection=True;";
            }
            else
            {
                string user = Properties.Settings.Default.UserName;
                string password = Properties.Settings.Default.Password;
                string druation = Properties.Settings.Default.ConDuration.ToString();
                Rafat.Data.ConString.ConStringValue = $"Server={server};Database={db};User Id={user};Password={password};Encrypt=false;Timeout={druation};";

            }
        }

    }
}

using Rafat.Code.Models;
using Rafat.Core;
using Rafat.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Code.Helper
{
    public static class SystemRecordHelper
    {
        public static void Add(string title, string description)
        {
            IDataHelper<SystemRecords> dataHelper = new SystemRecordsEF();
            SystemRecords systemRecords = new SystemRecords
            {
                CreatedDate = DateTime.Now,
                Description= description,
                Title= title,
                DeviceName=Environment.UserName,
                UserFullName=LocalUser.FullName,
                UsersId=LocalUser.Id,
                MachinId = GetMachineId()
                
            };
            dataHelper.Add(systemRecords);
        }

        private static string GetMachineId()
        {
            var networkinterfaces=NetworkInterface.GetAllNetworkInterfaces();
            string machineid = string.Empty;
            foreach (var networkinterface in networkinterfaces)
            {
                if(networkinterface.OperationalStatus==OperationalStatus.Up &&
                    networkinterface.NetworkInterfaceType!=NetworkInterfaceType.Tunnel&&
                    networkinterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    machineid=networkinterface.GetPhysicalAddress().ToString(); 
                }
            }

            if(machineid == string.Empty)
            {
                machineid = "Null";
            }
            return machineid;
        }

        
    }
}

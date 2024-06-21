using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Data.EF
{
    public interface IDataHelper<Table>
    {

        // Read { Admin | User }
        List<Table> GetAllData(); // Admin
        List<Table> GetDataByUser(string userId); // User
        List<Table> SearchAll(string searchIteam); // Admin 
        List<Table> SearchByUser(string userId,string searchIteam); // User
        Table Find(int id);

        // Write

        string Add(Table table);  // "1== Success" , Error
        string Edit(Table table);  // "1== Success" , Error
        string Delete(int id);  // "1== Success" , Error

        // Other 

        bool IsCanConnect();

    }
}

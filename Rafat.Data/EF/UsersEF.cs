using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rafat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Data.EF
{
    public class UsersEF : IDataHelper<Users>
    {
        private DBContext db;
        private Users users;
        public UsersEF()
        {
            db = new DBContext();
            users = new Users();
        }

        public string Add(Users table)
        {
            try
            {
                db.Users.Add(table);
                db.SaveChanges();
                return "1";

            }catch (Exception ex) { return ex.Message; }
        }

        public string Delete(int id)
        {
            try
            {
                users=Find(id);
                db.Users.Remove(users);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(Users table)
        {
            try
            {
                db = new DBContext();
                db.Users.Update(table);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public Users Find(int id)
        {
            try
            {
                return db.Users.Find(id) ?? new Users();    

            }
            catch
            {
                return new Users();
            }
        }

        public List<Users> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.Users.OrderByDescending(x=>x.Id).ToList();

            }
            catch
            {
                return new List<Users> ();
            }
        }

        public List<Users> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.Users.Where(x=>x.UserId==userId).OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<Users>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<Users> SearchAll(string searchIteam)
        {

            try
            {
                return db.Users.Where(x=>x.Id.ToString()==searchIteam || 
                x.UserId==searchIteam||
                x.Address.Contains(searchIteam)||
                x.Email.Contains(searchIteam)||
                x.FullName.Contains(searchIteam)||
                x.UserName.Contains(searchIteam)||
                x.Role.Contains(searchIteam)||
                x.CreatedDate.ToString().Contains(searchIteam)||
                x.EditedDate.ToString().Contains(searchIteam)
                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<Users>();
            }
        }

        public List<Users> SearchByUser(string userId, string searchIteam)
        {
            try
            {
                return db.Users.Where(x=>x.UserId==userId).Where(x => x.Id.ToString() == searchIteam ||
                x.UserId == searchIteam ||
                x.Address.Contains(searchIteam) ||
                x.Email.Contains(searchIteam) ||
                x.FullName.Contains(searchIteam) ||
                x.UserName.Contains(searchIteam) ||
                x.Role.Contains(searchIteam) ||
                x.CreatedDate.ToString().Contains(searchIteam) ||
                x.EditedDate.ToString().Contains(searchIteam)
                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<Users>();
            }
        }
    }
}

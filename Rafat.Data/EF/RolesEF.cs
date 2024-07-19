using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rafat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Data.EF
{
    public class RolesEF : IDataHelper<Roles>
    {
        private DBContext db;
        private Roles roles;
        public RolesEF()
        {
            db = new DBContext();
            roles = new Roles();
        }

        public string Add(Roles table)
        {
            try
            {
                db.Roles.Add(table);
                db.SaveChanges();
                return "1";

            }catch (Exception ex) { return ex.Message; }
        }

        public string Delete(int id)
        {
            try
            {
                roles=Find(id);
                db.Roles.Remove(roles);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(Roles table)
        {
            try
            {
                db = new DBContext();
                db.Roles.Update(table);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public Roles Find(int id)
        {
            try
            {
                return db.Roles.Find(id) ?? new Roles();    

            }
            catch
            {
                return new Roles();
            }
        }

        public List<Roles> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.Roles.OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<Roles> ();
            }
        }

        public List<Roles> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.Roles.Where(x => x.UsersId.ToString() == userId).OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<Roles>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<Roles> SearchAll(string searchIteam)
        {

            try
            {
                return db.Roles.Where(x=>x.Id.ToString()==searchIteam
               
                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<Roles>();
            }
        }

        public List<Roles> SearchByUser(string userId, string searchIteam)
        {
            try
            {
                return db.Roles.Where(x=>x.UsersId.ToString()==userId).Where(x => x.Id.ToString() == searchIteam
            
                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<Roles>();
            }
        }
    }
}

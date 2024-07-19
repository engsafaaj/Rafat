using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rafat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Data.EF
{
    public class EmployeesRecordsRecordsEF : IDataHelper<EmployeesRecords>
    {
        private DBContext db;
        private EmployeesRecords EmployeesRecords;
        public EmployeesRecordsRecordsEF()
        {
            db = new DBContext();
            EmployeesRecords = new EmployeesRecords();
        }

        public string Add(EmployeesRecords table)
        {
            try
            {
                db.EmployeesRecords.Add(table);
                db.SaveChanges();
                return "1";

            }catch (Exception ex) { return ex.Message; }
        }

        public string Delete(int id)
        {
            try
            {
                EmployeesRecords=Find(id);
                db.EmployeesRecords.Remove(EmployeesRecords);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(EmployeesRecords table)
        {
            try
            {
                db = new DBContext();
                db.EmployeesRecords.Update(table);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public EmployeesRecords Find(int id)
        {
            try
            {
                return db.EmployeesRecords.Find(id) ?? new EmployeesRecords();    

            }
            catch
            {
                return new EmployeesRecords();
            }
        }

        public List<EmployeesRecords> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.EmployeesRecords.OrderByDescending(x=>x.Id).ToList();

            }
            catch
            {
                return new List<EmployeesRecords> ();
            }
        }

        public List<EmployeesRecords> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.EmployeesRecords.Where(x=>x.UsersId==userId).OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<EmployeesRecords>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<EmployeesRecords> SearchAll(string searchIteam)
        {

            try
            {
                return db.EmployeesRecords.Where(x=>x.Id.ToString()==searchIteam || 
                x.UsersId==searchIteam||

                x.Name.Contains(searchIteam)||
                x.JobTitle.Contains(searchIteam)||
                x.EmpState==searchIteam||
                x.LastPromotionDate.ToString()== searchIteam ||


                x.CurrentDegree.ToString()== searchIteam ||
                x.CurrentStage.ToString()== searchIteam ||
                x.CurrentSalary.ToString()== searchIteam ||
                x.CurrentDate.ToString()== searchIteam ||

                x.NextDegree.ToString() == searchIteam ||
                x.NextStage.ToString() == searchIteam ||
                x.NextSalary.ToString() == searchIteam ||
                x.NextDate.ToString() == searchIteam ||

                x.Note.Contains(searchIteam) ||


                x.AddedDate.ToString() == searchIteam ||
                x.UpdateDate.ToString() == searchIteam 

                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<EmployeesRecords>();
            }
        }

        public List<EmployeesRecords> SearchByUser(string userId, string searchIteam)
        {
            try
            {
                return db.EmployeesRecords.Where(x=>x.UsersId==userId).Where(x => x.Id.ToString() == searchIteam ||
                x.UsersId == searchIteam ||

                x.Name.Contains(searchIteam) ||
                x.JobTitle.Contains(searchIteam) ||
                x.EmpState == searchIteam ||
                x.LastPromotionDate.ToString() == searchIteam ||


                x.CurrentDegree.ToString() == searchIteam ||
                x.CurrentStage.ToString() == searchIteam ||
                x.CurrentSalary.ToString() == searchIteam ||
                x.CurrentDate.ToString() == searchIteam ||

                x.NextDegree.ToString() == searchIteam ||
                x.NextStage.ToString() == searchIteam ||
                x.NextSalary.ToString() == searchIteam ||
                x.NextDate.ToString() == searchIteam ||

                x.Note.Contains(searchIteam) ||


                x.AddedDate.ToString() == searchIteam ||
                x.UpdateDate.ToString() == searchIteam
                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<EmployeesRecords>();
            }
        }
    }
}

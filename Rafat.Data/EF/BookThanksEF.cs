using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rafat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Data.EF
{
    public class BookThanksEF : IDataHelper<BookThanks>
    {
        private DBContext db;
        private BookThanks bookThanks;
        public BookThanksEF()
        {
            db = new DBContext();
            bookThanks = new BookThanks();
        }

        public string Add(BookThanks table)
        {
            try
            {
                db.BookThanks.Add(table);
                db.SaveChanges();
                return "1";

            }catch (Exception ex) { return ex.Message; }
        }

        public string Delete(int id)
        {
            try
            {
                bookThanks=Find(id);
                db.BookThanks.Remove(bookThanks);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public string Edit(BookThanks table)
        {
            try
            {
                db = new DBContext();
                db.BookThanks.Update(table);
                db.SaveChanges();
                return "1";

            }
            catch (Exception ex) { return ex.Message; }
        }

        public BookThanks Find(int id)
        {
            try
            {
                return db.BookThanks.Find(id) ?? new BookThanks();    

            }
            catch
            {
                return new BookThanks();
            }
        }

        public List<BookThanks> GetAllData()
        {
            try
            {
                db = new DBContext();
                return db.BookThanks.OrderByDescending(x=>x.Id).ToList();

            }
            catch
            {
                return new List<BookThanks> ();
            }
        }

        public List<BookThanks> GetDataByUser(string userId)
        {
            try
            {
                db = new DBContext();
                return db.BookThanks.Where(x=>x.UserId==userId).OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<BookThanks>();
            }
        }

        public bool IsCanConnect()
        {
            db = new DBContext(); return db.Database.CanConnect();
        }

        public List<BookThanks> SearchAll(string searchIteam)
        {

            try
            {
                return db.BookThanks.Where(x=>x.Id.ToString()==searchIteam || 
                x.UserId==searchIteam||
                x.AddedDate.ToString()==searchIteam||
                x.BookThankDate.ToString()==searchIteam||
                x.Ref.ToString()==searchIteam||
                x.Note.Contains(searchIteam)
               
                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<BookThanks>();
            }
        }

        public List<BookThanks> SearchByUser(string userId, string searchIteam)
        {
            try
            {
                return db.BookThanks.Where(x=>x.UserId ==userId).Where(x => x.Id.ToString() == searchIteam ||
              x.UserId == searchIteam ||
                x.AddedDate.ToString() == searchIteam ||
                x.BookThankDate.ToString() == searchIteam ||
                x.Ref.ToString() == searchIteam ||
                x.Note.Contains(searchIteam)
                )
                    .OrderByDescending(x => x.Id).ToList();

            }
            catch
            {
                return new List<BookThanks>();
            }
        }
    }
}

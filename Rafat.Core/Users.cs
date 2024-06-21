using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Core
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsSecondaryUser { get; set; }
        public string UserId{ get; set; }
        public string? Phone{ get; set; }
        public string? Email{ get; set; }
        public string? Address{ get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime EditedDate{ get; set; }


        // Navigations
        public List<Roles> Roles { get; set; }

    }
}

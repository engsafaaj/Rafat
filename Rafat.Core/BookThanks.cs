using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Core
{
    public class BookThanks
    {
        public int Id { get; set; }
        public int EffectValue { get; set; }
        public string Ref { get; set; }
        public DateTime BookThankDate { get; set; }
        public string Note { get; set; }

        public DateTime AddedDate { get; set; }

        // Navigations
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }
        public string UserId {  get; set; } 

    }
}

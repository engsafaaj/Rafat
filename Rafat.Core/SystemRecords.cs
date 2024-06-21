using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Core
{
    public class SystemRecords
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string DeviceName { get; set; }
        public string MachinId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigations
        public int UsersId { get; set; }
    }
}

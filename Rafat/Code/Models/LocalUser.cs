using Rafat.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafat.Code.Models
{
    internal static class LocalUser
    {
        public static int Id { get; set; }
        public static string FullName { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string Role { get; set; }
        public static bool IsSecondaryUser { get; set; }
        public static string UserId { get; set; }
        public static string? Phone { get; set; }
        public static string? Email { get; set; }
        public static string? Address { get; set; }
        public static DateTime CreatedDate { get; set; }
        public static DateTime EditedDate { get; set; }


        // Navigations
        public static List<Roles> Roles { get; set; }
        public static List<SystemRecords> SystemRecords { get; set; }
    }
}

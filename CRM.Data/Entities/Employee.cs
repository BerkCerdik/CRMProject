using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Entities
{
    public class Employee : BaseEntity
    {
        [MaxLength(80)]
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}

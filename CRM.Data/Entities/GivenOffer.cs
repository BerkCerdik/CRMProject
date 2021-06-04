using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Entities
{
    public class GivenOffer : BaseEntity
    {
        public string AuthorizedPerson { get; set; }
        public string Follower { get; set; }
        public DateTime EndingTime { get; set; }

        //File
    }
}

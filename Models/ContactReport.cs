using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ContactReport
    {
        public string Location { get; set; }

        public int LocationCount { get; set; }

        public int PeopleInLocation { get; set; }

        public int PhonesInLocation { get; set; }


    }
}

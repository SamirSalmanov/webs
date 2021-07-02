using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Websuper.Models
{
    public class ContactUs : BaseEntity
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Map { get; set; }

    }
}

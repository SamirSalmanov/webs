using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Websuper.Models
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Phone { get; set; }
        public string PhotoURL { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Websuper.Models
{
    public class OneBlog : BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
    }
}

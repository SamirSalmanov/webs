using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Websuper.Models
{
    public class Gallery : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
        public virtual Category Category { get; set; }
    }
}

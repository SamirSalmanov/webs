using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Websuper.Models;

namespace Websuper.ViewModel
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Services> Services { get; set; }
        public List<Gallery> Galleries { get; set; }
        public List<Blog> Blogs { get; set; }
        public ConsultNow ConsultNow { get; set; }
        public OneBlog OneBlog { get; set; }
        public Gallery Gallery { get; set; }

    }
}

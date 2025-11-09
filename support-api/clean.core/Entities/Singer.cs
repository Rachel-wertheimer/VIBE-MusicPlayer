using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core.Entities
{
    public class Singer
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public List<Songs> Songs { get; set; }

        public List<Albums> Albums { get; set; }
    }
}

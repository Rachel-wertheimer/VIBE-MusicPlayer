using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core.Entities
{
    public class Albums
    {
        public int Id { get; set; }
        public string NameAlbums { get; set; }
        public string NameCertore { get; set; }
        public int year { get; set; }
        public List<Songs> Songs { get; set; }

        //public string IdSinger { get; set; }

        //public Singer singer;


    }
}

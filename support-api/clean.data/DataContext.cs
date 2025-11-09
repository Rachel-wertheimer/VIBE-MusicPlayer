using clean.core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.data
{
    public class DataContext: DbContext
    {
        public DbSet<Singer> dataSinger { get; set; }
        public DbSet<Songs> dataSonges { get; set; }
        public DbSet<Albums> dataAlbums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SSNMLFD;Database=Mp3Rachely;Trusted_Connection=True;");
        }

    }
}

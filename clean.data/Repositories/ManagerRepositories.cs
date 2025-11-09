using clean.core.Entities;
using clean.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.data.Repositories
{

    public class ManagerRepositories : IRepositorirsManager
    {
        private readonly DataContext _context;
        public IRepository<Albums, int> Album { get; }
        public IRepository<Songs, int> Songs { get; }

        public IRepository<Singer, string> Singer { get; }
        public ManagerRepositories(DataContext context, IRepository<Albums, int> album, IRepository<Songs, int> songs, IRepository<Singer, string> singer)
        {
            _context = context;
            Album = album;
            Songs = songs;
            Singer = singer;

        }

        public async Task Saveasync()
        {
           await _context.SaveChangesAsync();
        }
    }
}


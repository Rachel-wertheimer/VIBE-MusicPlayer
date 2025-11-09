using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using clean.core.DTOs;
using clean.core.Entities;
using clean.core.Repositories;
using clean.data.Repositories;

namespace clean.service.service
{
    public class SongService
    {

        //private AlbumsInterface _albumsInterface;
        //private IRepositorirsIntrface _repositorirsManger;
        private IMapper _mapper;
        private IRepositorirsManager _repositorirsManager;
        private IRepository<Songs, int> _repository;
        public SongService(IRepositorirsManager repositorirsManager, IRepository<Songs, int> repository, IMapper mapper)
        {

            _mapper = mapper;
            _repositorirsManager = repositorirsManager;
            _repository = repository;
        }
        public List<SongsDTO> GetAll()
        {
             return _mapper.Map<List<SongsDTO>>(_repository.GetAll());
        }
        public SongsDTO GetById(int code)
        {
                return _mapper.Map<SongsDTO>(_repository.GetById(code));
        }
        public async Task Addasync(Songs songs)
        {
            _repository.Add(songs);
            _repositorirsManager.Saveasync();
        }
        public async Task Putasync(Songs songs)
        {
            _repository.Put(songs);
            _repositorirsManager.Saveasync();

        }
        public async Task Deleteasync(int id)
        {
            _repository.Delete(id);
            _repositorirsManager.Saveasync();
        }
    }
}

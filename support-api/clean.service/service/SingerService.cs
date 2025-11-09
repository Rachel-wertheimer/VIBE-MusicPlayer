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
    public class SingerService
    {
        //private AlbumsInterface _albumsInterface;
        //private IRepositorirsIntrface _repositorirsManger;
        private IMapper _mapper;
        private IRepositorirsManager _repositorirsManager;
        private IRepository<Singer, string> _repository;
        public SingerService(IRepositorirsManager repositorirsManager, IRepository<Singer, string> repository, IMapper mapper)

        {
            _mapper = mapper;
            _repositorirsManager = repositorirsManager;
            _repository = repository;
        }
        public List<SingerDTO> GetAll()
        {
            return _mapper.Map<List<SingerDTO>>(_repository.GetAll());

        }
        public SingerDTO GetById(string code)
        {
            return _mapper.Map<SingerDTO>(_repository.GetById(code));
        }
        public async Task Addasync(Singer singer)
        {
            _repository.Add(singer);
            _repositorirsManager.Saveasync();
        }
        public async Task Putasync(Singer singer)
        {
            _repository.Put(singer);
            _repositorirsManager.Saveasync();

        }
        public async Task Deleteasync(string id)
        {
            _repository.Delete(id);
            _repositorirsManager.Saveasync();
        }
    }
}

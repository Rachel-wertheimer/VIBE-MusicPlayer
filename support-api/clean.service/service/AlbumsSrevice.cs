using AutoMapper;
using clean.core.DTOs;
using clean.core.Entities;
using clean.core.Repositories;
using clean.data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.service.service
{
    public class AlbumsSrevice
    {

        private IMapper _mapper;
        private IRepositorirsManager _repositorirsManager;
        private IRepository<Albums, int> _repository;
        public AlbumsSrevice(IRepositorirsManager repositorirsManager, IRepository<Albums, int> repository, IMapper mapper)
        {

            _repositorirsManager = repositorirsManager;
            _repository = repository;
            _mapper = mapper;
        }
        public List<AlbumsDTO> GetAll()
        {
            return _mapper.Map<List<AlbumsDTO>>(_repository.GetAll());
        }
        public AlbumsDTO GetById(int code)
        {
            return _mapper.Map<AlbumsDTO>(_repository.GetById(code));
        }
        public async Task Addasync(Albums album)
        {
            _repository.Add(album);
            await _repositorirsManager.Saveasync();
        }
        public async Task Putasync(Albums albums)
        {
            _repository.Put(albums);
           await _repositorirsManager.Saveasync();

        }

        public async Task Deleteasync(int id)
        {
            _repository.Delete(id);
             await _repositorirsManager.Saveasync();
             
        }
    }
}

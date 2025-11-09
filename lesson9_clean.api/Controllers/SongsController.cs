using Microsoft.AspNetCore.Mvc;
using clean.core.Entities;
using clean.service.service;
using clean.core.DTOs;

using clean.api.Models;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson9_clean.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SongsController : ControllerBase
    {
        private SongService _songService;

        public SongsController(SongService songService)
        {
            _songService = songService;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_songService.GetAll());
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_songService.GetById(id));
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SongsModel value)
        {
            var Song = new Songs {  NameSonges = value.NameSonges , NameCertore =value.NameCertore};
            await _songService?.Addasync(Song);
            return Created("",Song);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id ,[FromBody] SongsModel value)
        {
            var Song = new Songs {Id = id, NameSonges = value.NameSonges, NameCertore = value.NameCertore };
             await _songService.Putasync(Song);    
            return Accepted(Song);
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _songService.Deleteasync(id);
           return Ok();
        }
    }
}

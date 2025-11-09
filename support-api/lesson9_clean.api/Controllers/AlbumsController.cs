using clean.core.DTOs;
using clean.core.Entities;
using clean.service.service;
using clean.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clean.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumsController : ControllerBase
    {
        private AlbumsSrevice _albumsSrevice;

        public AlbumsController(AlbumsSrevice albumsSrevice)
        {
            _albumsSrevice = albumsSrevice;
        }

        // GET: api/<AlbumsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_albumsSrevice.GetAll());
        }

        // GET api/<AlbumsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_albumsSrevice.GetById(id));
        }

        // POST api/<AlbumsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlbumsModel value)
        {
            Albums albums = new Albums { NameAlbums = value.NameAlbums, NameCertore = value.NameCertore, year = value.year };
            await _albumsSrevice.Addasync(albums);
            return Created("created", albums);
        }


        // PUT api/<AlbumsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlbumsModel value)
        {
            var albums = new Albums { Id = id, NameAlbums = value.NameAlbums, NameCertore = value.NameCertore, year = value.year };
            await _albumsSrevice.Putasync(albums);
            return Accepted(albums);

        }


        // DELETE api/<AlbumsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _albumsSrevice.Deleteasync(id);
            return Ok();

        }
    }
}

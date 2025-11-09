using Microsoft.AspNetCore.Mvc;
using clean.core.Entities;
using clean.service.service;
using clean.api.Models;
using clean.core.DTOs;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace clean.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SingersController : ControllerBase
    {
        private SingerService _singerService;

        public SingersController(SingerService singerService)
        {
            _singerService = singerService;
        }

        // GET: api/<SingersController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_singerService?.GetAll());
        }

        // GET api/<SingersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            return Ok(_singerService?.GetById(id));
        }

        // POST api/<SingersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SingerModel value)
        {
            var Singer = new Singer { Id = value.Id, Name = value.Name  };
           await _singerService?.Addasync(Singer);
            return Created("",Singer);
        }

        // PUT api/<SingersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id,[FromBody] SingerModel value)
        {
            var Singer = new Singer { Id = id, Name = value.Name };
             await _singerService.Putasync(Singer);
            return Accepted(Singer);
        }

        // DELETE api/<SingersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
           await _singerService.Deleteasync(id);
           return Ok();
        }
    }
}

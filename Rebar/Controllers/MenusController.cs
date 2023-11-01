using Microsoft.AspNetCore.Mvc;
using Rebar.DataAccess;
using Rebar.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        // GET: api/<MenusController>
        [HttpGet]
        public Task<List<ShakeModle>> Get()
        {
            MenuAccess db = new();
            return db.GetAllShake();

        }


        // GET api/<MenusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MenusController>
        [HttpPost]
        public ShakeModle Post(ShakeModle shake)
        {
            MenuAccess db = new();
            db.CreatSheke(shake);
            return shake;
        }


        // PUT api/<MenusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

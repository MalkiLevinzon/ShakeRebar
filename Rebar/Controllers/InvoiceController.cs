using Microsoft.AspNetCore.Mvc;
using Rebar.DataAccess;
using Rebar.Models;
using Rebar.Modles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        // GET: api/<InvoiceController>
        [HttpGet]
        public Task<List<InvoiceModle>> Get()
        {
            InvoiceAccess db = new();
            return db.GetAllInvoice();

        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public InvoiceModle Post()
        {
            InvoiceAccess db = new();
            
            var invoice =db.CreatInvoice();
            return invoice;
        }


        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

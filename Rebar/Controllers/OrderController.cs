using Microsoft.AspNetCore.Mvc;
using Rebar.DataAccess;
using Rebar.Modles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpGet]
        public Task<List<OrderModle>> Index()
        {
            OrderAccess db = new();
            return db.GetAllOrders();

        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        // public OrderModle Post(string[] name ,string[] sizeIs, int sale, string customerName)
        public OrderModle Post([FromBody] OrderDTO orderDTO)
        {
            {
                List<Shake> shakes = new();

                for (int i = 0; i < orderDTO.Name.Count() && i < orderDTO.SizeIs.Count(); i++)
                {
                    Size size = (Size)Enum.Parse(typeof(Size), orderDTO.SizeIs[i] ?? "ther is not type of size");
                    shakes.Add(new Shake(orderDTO.Name[i], size));
                }

                OrderModle order = new(shakes, orderDTO.Sale, orderDTO.CustomerName);
                OrderAccess db = new();
                var result = db.CreatOrder(order);
                return result;
            }
            //List<Shake> shakes = new();

            //for (int i = 0; i < name.Count() && i < sizeIs.Count();i++) 
            //{
            //    Size size = (Size)Enum.Parse(typeof(Size), sizeIs[i] ?? "ther is not type of size");

            //    shakes.Add(new Shake(name[i], size));
            //}
            //OrderModle order=new(shakes, sale, customerName);
            //OrderAccess db = new();
            //var result = db.CreatOrder(order);
            //return result;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class OrderDTO
    {
        public List<string> Name { get; set; }
        public List<string> SizeIs { get; set; }
        public int Sale { get; set; }
        public string CustomerName { get; set; }
    }
}

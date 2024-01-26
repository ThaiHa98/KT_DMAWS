using KT_DMAWS.DBContext;
using KT_DMAWS.Interfaces;
using KT_DMAWS.Model;
using Microsoft.AspNetCore.Mvc;

namespace KT_DMAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly KT_DMAWSDBContext _dbContext;
        private readonly IOrderInterfaces _interfaces;
        public OrderController(KT_DMAWSDBContext dbContext, IOrderInterfaces interfaces)
        {
            _dbContext = dbContext;
            _interfaces = interfaces;
        }
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data");
            }
            var create = _interfaces.CreateOrder(order);
            if(create != null) 
            {
                return Ok(create);
            }
            else
            {
                return StatusCode(500, "Error creating the order");
            }
        }
        [HttpPost ("updateOrder")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            var updated = _interfaces.UpdateOrder(id, updatedOrder);

            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }
    }
}

using FirstApproach.Model;
using FirstApproach.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace FirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRep _orderRepository;
        public OrderController(IOrderRep orderRepositry)
        {
            _orderRepository = orderRepositry;
        }
        // GET: api/<orderController>
        [HttpGet]
        public IActionResult Get()
        {
             var products = _orderRepository.GetOrders();
          //  return Ok(_productRepository.GetProducts());
            return new OkObjectResult(products);
        }
        // GET api/<orderController>/5
        [HttpGet("By Id")]
        public IActionResult Get(int id)
        {
            Order order = _orderRepository.GetOrdertByID(id);
            return new OkObjectResult(order);
        }
        // POST api/<OrderController>
        [HttpPost("InsertProduct")]
        public IActionResult Post([FromBody] Order order)
        {
            using (var scope = new TransactionScope())
            {
                _orderRepository.InsertOrder(order);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
            }
        }
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (order != null)
            {
                using (var scope = new TransactionScope())
                {
                    _orderRepository.UpdateOrder(order);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _orderRepository.DeleteOrder(id);
            return new OkResult();
        }

    }
}

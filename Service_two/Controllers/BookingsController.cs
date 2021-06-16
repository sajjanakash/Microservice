using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_two.Model;
using Service_two.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Service_two.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly IBookingRepo _bookRepository;
        public BookingsController(IBookingRepo bookRepositry)
        {
            _bookRepository = bookRepositry;
        }
        // GET: api/<BookingsController>
        public IActionResult Get()
        {
            var booking = _bookRepository.GetBookingDetails();
            //  return Ok(_productRepository.GetProducts());
            return new OkObjectResult(booking);
        }

        // GET api/<BookingsController>/5
        [HttpGet("By Id")]
        public IActionResult Get(int BookId)
        {
            Booking book = _bookRepository.GetBookingDetailstByID(BookId);
            return new OkObjectResult(book);
        }

        // POST api/<BookingsController>
        [HttpPost]
        [HttpPost("InsertProduct")]
        public IActionResult Post([FromBody] Booking book)
        {
            using (var scope = new TransactionScope())
            {
                _bookRepository.AddBookings(book);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = book.BookingId }, book);
            }
        }
        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Booking book)
        {
            if (book != null)
            {
                using (var scope = new TransactionScope())
                {
                    _bookRepository.UpdateBookingDetails(book);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookRepository.DeleteBookingBasedOnId(id);
            return new OkResult();
        }
    }
}

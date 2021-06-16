using Microsoft.EntityFrameworkCore;
using Service_two.ContextDB;
using Service_two.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service_two.Repository
{
    public class BookingRepo:IBookingRepo

    {
        private readonly BookingDBContext _dbContext;
        public BookingRepo(BookingDBContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void AddBookings(Booking book)
        {
            _dbContext.Add(book);
            Save();
        }

        public void DeleteBookingBasedOnId(int BookId)
        {
            var product = _dbContext.Bookings.Find(BookId);
            _dbContext.Bookings.Remove(product);
            Save();
        }

        public List<Booking> GetBookingDetails()
        {
            return _dbContext.Bookings.ToList();
        }

        public Booking GetBookingDetailstByID(int BookId)
        {
            return _dbContext.Bookings.Find(BookId);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBookingDetails(Booking book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            Save();
        }
    }
}

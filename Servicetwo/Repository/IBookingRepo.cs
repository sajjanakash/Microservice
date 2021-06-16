using Servicetwo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicetwo.Repository
{
  public  interface IBookingRepo
    {
        List<Booking> GetBookingDetails();
       
        void AddBookings(Booking book);
        void DeleteBookingBasedOnId(int BookId);
        void UpdateBookingDetails(Booking book);
        void Save();
        Booking GetBookingDetailstByID(int BookId);
    }
}

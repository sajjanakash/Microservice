using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Service_two.Model
{
    public class Booking
    {
        [Key]
        public Guid BookingId
        { get; set; }
        public string Location
        { get; set; }
    }
}

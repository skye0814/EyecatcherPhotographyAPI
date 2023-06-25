using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppointmentPlace
    {
        [Key]
        public long AppointmentPlaceID { get; set; }
        public string? PlaceName { get; set; }
    }
}

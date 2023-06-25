using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class BillingDetails
    {
        [Key]
        public long ReceiptID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime AppointmentDate { get; set; }

        // Navigation Prop
        public IEnumerable<Cart>? Carts { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("AppointmentPlaceID")]
        public virtual AppointmentPlace? AppointmentPlace { get; set; }

    }
}

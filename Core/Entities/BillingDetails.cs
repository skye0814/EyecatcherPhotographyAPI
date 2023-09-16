using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class BillingDetails
    {
        [Key]
        public Guid BillingDetailsID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime AppointmentDate { get; set; }



        // Navigation Prop
        public IEnumerable<Cart>? Carts { get; set; }
        public Guid? CartID { get; set; }


        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }
        public Guid? CustomerID { get; set; }

        [ForeignKey("AppointmentPlaceID")]
        public virtual AppointmentPlace? AppointmentPlace { get; set; }

    }
}

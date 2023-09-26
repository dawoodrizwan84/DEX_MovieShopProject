using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DEX_MovieShopProject.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
     

        [DisplayName("Order Date")]
        [Required]
        public DateTime OrderDate { get; set; }

        [DisplayName("Customer Id")]
        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}

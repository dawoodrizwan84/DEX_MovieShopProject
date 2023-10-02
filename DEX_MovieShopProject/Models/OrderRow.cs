using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DEX_MovieShopProject.Models
{
    public class OrderRow
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Order Id")]
        [Required]
        public int OrderID { get; set; }

        [DisplayName("Movie Id")]
        [Required]
        public int MovieId { get; set; }

        [DisplayName("Price")]
        [Required]

        public decimal Price { get; set; }

        public virtual Movie Movie { get; set; }   
        
        public virtual Order Order { get; set; }


    }
}

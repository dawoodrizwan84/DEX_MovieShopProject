using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DEX_MovieShopProject.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Billing Address")]
        [Required]
        public string BillingAddress { get; set; }

        [DisplayName("Billing Zip")]
        [Required]
        public int BillingZip { get; set; }

        [DisplayName("Billing City")]
        [Required]
        public string BillingCity { get; set; }

        [DisplayName("Delivery Address")]
        
        public string DeliveryAddress { get; set;}

        [DisplayName("Delivery Zip")]
        [Required]
        public string DeliveryZip { get;set;}

        [DisplayName("Delivery Address")]
        public string DeliveryCity { get;set;}

        [DisplayName("Email Address")]
        [Required]
        public string EmailAddress { get; set; }

        [DisplayName("Phone No")]
        [Required]
        public string PhoneNo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }  


    }
}

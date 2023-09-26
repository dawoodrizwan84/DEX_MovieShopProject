using System.ComponentModel.DataAnnotations;

namespace DEX_MovieShopProject.Models
{
    public class Movie
    {
        //[Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required]
        public string Title { get; set; }


        [Display(Name = "Director")]
        [Required]
        public string Director { get; set; }

        [Display(Name = "Release Year")]
        [Required]
        public int ReleaseYear { get; set; }

        [Display(Name = "Price")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImgUrl { get; set; }

        //public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}

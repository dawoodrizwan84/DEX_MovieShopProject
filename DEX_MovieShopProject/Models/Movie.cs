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
        [StringLength(maximumLength:100,
            MinimumLength =1, ErrorMessage ="Max 100 characters, minimum 2 characters.")]
        public string Title { get; set; }


        [Display(Name = "Director")]
        [Required]
        public string Director { get; set; }

        [Display(Name = "Movie Description")]

        [StringLength(300)]
        public string Description { get; set; }

        [Display(Name = "Release Year")]
        [Required]
        public string ReleaseYear { get; set; }

        [Display(Name = "Price")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImgUrl { get; set; }


        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}

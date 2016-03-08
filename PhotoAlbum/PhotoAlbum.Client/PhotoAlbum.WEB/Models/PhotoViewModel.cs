using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PhotoAlbum.WEB.Models
{
    public class PhotoViewModel
    {
        [Required(ErrorMessage = "Please enter the name of photo")]
        [StringLength(256)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter the description of photo")]
        [StringLength(1024)]
        public string Description { get; set; }

        public double AverageRating { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Creating time")]
        public DateTime TimeOfCreation { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Guid PhotoId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
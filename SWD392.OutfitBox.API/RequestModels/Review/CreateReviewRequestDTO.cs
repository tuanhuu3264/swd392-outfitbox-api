using SWD392.OutfitBox.API.DTOs.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Review
{
    public class CreateReviewRequestDTO
    {
        [Required(ErrorMessage = "The content is required.")]
        public string Content { get; set; } = string.Empty;
        [Required(ErrorMessage = "The title is required.")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "The number stars is required.")]
        [Range(1,5, ErrorMessage ="The number of stars is over range 1-5.")]
        public int NumberStars { get; set; }
        [Required(ErrorMessage = "The customer id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The customer id is over range of data.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The package id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The package id is over range of data.")]
        public int PackageId { get; set; }
        public List<ImageRequestModel>? ReviewImages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.API.DTOs.Product
{
    public class CreatedProductDto
    {
        [Required(ErrorMessage ="The name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The price is required.")]
        [Range(1, float.MaxValue, ErrorMessage = "The price is over range of data.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "The size is required.")]
        public string? Size { get; set; }
        [Required(ErrorMessage = "The deposit is required.")]
        [Range(1, float.MaxValue, ErrorMessage = "The deposit is over range of data.")]
        public float Deposit { get; set; }
        [Required(ErrorMessage = "The description is required.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "The id category is required.")]
        [Range(1, float.MaxValue, ErrorMessage = "The id category is over range of data.")]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "The id brand is required.")]
        [Range(1, float.MaxValue, ErrorMessage = "The id brand is over range of data.")]
        public int IdBrand { get; set; }
        [Required(ErrorMessage = "The type is required.")]
        public string? Type { get; set; }
        [Required(ErrorMessage = "The quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity is over range of data.")]
        public int Quantity { get; set; }
        public List<ImageRequestModel>? Images { get; set; }

    }
}

using SWD392.OutfitBox.BusinessLayer.Models.Requests.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Models.Responses.Package
{
    public class UpdatePackageResponseDTO
    {   
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }

        public CategoryPackageDTO[]? CategoryPackages { get; set; }
    }
}

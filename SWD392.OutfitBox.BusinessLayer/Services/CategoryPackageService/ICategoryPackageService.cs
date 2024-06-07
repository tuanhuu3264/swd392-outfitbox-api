using SWD392.OutfitBox.BusinessLayer.Models.Requests.CategoryPackage;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Package;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.CategoryPackage;
using SWD392.OutfitBox.Core.Models.Responses.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.CategoryPackageService
{
    public interface ICategoryPackageService
    {
        public Task<List<CategoryPackageDTO>> GetAllCategoryPackagesByPackageId(int packageId);
        public Task<CreateCategoryPackageResponseDTO> CreatePackage(CreateCategoryPackageRequestDTO request);
        public Task<UpdateCategoryPackageResponseDTO> UpdatePackage(UpdateCategoryPackageRequestDTO request);
        public Task<DeleteCategoryPackageResponseDTO> DeletePackageById(int id); 
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
    public class CategoryPackageEndpoints
    {
        public const string GetAllCategoryPackagesByPackageId = "/category-packages/by-package-id/{packageId}";
        public const string CreateCategoryPackage = "/category-packages";
        public const string UpdateCategoryPackage = "/category-packages";
        public const string DeleteCategoryPackage = "/category-packages/{id}";
    }
}

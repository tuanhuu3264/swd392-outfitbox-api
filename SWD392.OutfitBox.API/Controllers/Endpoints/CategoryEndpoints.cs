using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SWD392.OutfitBox.API.Controllers.Endpoints
{

    public static class CategoryEndpoints
    {
        public const string GetAllCategories = "/categories";
        public const string GetCategoryById = "/categories/{id}";
        public const string CreateCategory = "/categories";
        public const string UpdateCategory = "/categories";
        public const string ActiveOrDeactiveCategory = "/categories/active-deactive";
    }
}

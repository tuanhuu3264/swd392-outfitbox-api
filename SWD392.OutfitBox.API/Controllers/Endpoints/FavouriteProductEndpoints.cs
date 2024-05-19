namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
    public static class FavouriteProductEndpoints
    {
        public const string CreateFavouriteProduct = "/favourite-products/by-customer-id/{customerId}/by-product-id/{productId}";
        public const string DeleteFavouriteProduct = "/favourite-products/by-customer-id/{customerId}/by-product-id/{productId}";
        public const string GetAllFavouriteProductByCustomerId = "/favourite-products/by-customer-id/{customerId}";
    }
}

namespace SWD392.OutfitBox.API.Controllers.Endpoints
{
    public static class PackageEndPoints
    {
        public const string GetAllPackages = "packages";
        public const string GetAllEnabledPackages = "packages/enabled";
        public const string CreatePackage = "packages";
        public const string UpdatePackage = "packages";
        public const string ActiveOrDeactivePackage = "packages/active-or-deactive/{id}";
    }
}

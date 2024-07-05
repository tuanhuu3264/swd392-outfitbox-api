using SWD392.OutfitBox.API.DTOs.ItemInUserPackage;

namespace SWD392.OutfitBox.API.RequestModels.CustomerPackage
{
    public class CustomerPackageRequest
    {
        public int CustomerId { get; set; }
        public int PackageId { get; set; }
        public List<CreatedItemInPackage> createdItemInPackages { get; set; }
        public int WalletId {  get; set; }
    }
}

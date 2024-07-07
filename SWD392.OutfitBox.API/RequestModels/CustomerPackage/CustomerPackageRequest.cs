using SWD392.OutfitBox.API.DTOs.ItemInUserPackage;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

namespace SWD392.OutfitBox.API.RequestModels.CustomerPackage
{
    public class CustomerPackageRequest
    {
        public int CustomerId { get; set; }
        public int PackageId { get; set; }
        public DateTime DateFrom { get; set; }
        public List<CreateItemInUserPackage> CreateItems { get; set; }
    }
    public class CreateItemInUserPackage
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

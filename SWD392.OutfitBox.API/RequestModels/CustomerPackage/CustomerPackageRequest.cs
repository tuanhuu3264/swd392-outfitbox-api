using SWD392.OutfitBox.API.DTOs.ItemInUserPackage;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

namespace SWD392.OutfitBox.API.RequestModels.CustomerPackage
{
    public class CustomerPackageRequest
    {
        
        public DateTime DateFrom { get; set; }
        public string? ReceiverName {  get; set; }
        public string? ReceiverPhone { get; set; }
        public string? ReceiverAddress { get; set; }
        public List<CreateItemInUserPackage> CreateItems { get; set; }
    }
    public class CreateItemInUserPackage
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

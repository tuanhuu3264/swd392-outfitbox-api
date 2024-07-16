using static ServiceStack.LicenseUtils;
using SWD392.OutfitBox.API.DTOs.ProductReturnOrder;
using System.ComponentModel.DataAnnotations;

namespace SWD392.OutfitBox.API.RequestModels.ReturnOrder
{
    public class UpdateReturnOrdeeRequest
    {
        public List<ChangeStatusProductReturnOrder>? Products {  get; set; }
    }
    public class ChangeStatusProductReturnOrder
    {
        public int? Id { get; set; }
        public double? ThornMoney { get; set; }
        public int? DamagedLevel { get; set; }
    }
}

using SWD392.OutfitBox.BusinessLayer.BusinessModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<ResponsePayment> GetInformationPayment(VNPayModel dto);
        Task<string> CallAPIPayByUserId(int userId, double money);
    }
}

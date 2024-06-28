
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.AuthService
{
    public interface IAuthService
    {
        public Task<LoginModel> LoginSystem(string email, string password);
        public  Task<LoginModel> LoginPartner(string email, string password);

       

    }
}

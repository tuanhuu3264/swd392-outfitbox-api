using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.FirebaseService
{
    public interface IFirebaseService
    {
        public Task<LoginModel> VerifyFirebaseThirdPartToken(string accessToken);
        public Task<LoginModel> VerifyFirebaseNormalToken(string accessToken);
        public  Task<LoginModel> GetAccessTokenFromRefeshToken(string refreshToken);
      
    }
}

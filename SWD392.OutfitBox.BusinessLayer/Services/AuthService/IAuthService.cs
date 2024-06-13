
using SWD392.OutfitBox.BusinessLayer.Models.Requests;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.AuthService
{
    public interface IAuthService
    {
        public Task<LoginSystemResponseDTO> LoginSystem(LoginSystemRequestDTO loginSystemRequestDTO);
        public  Task<LoginPartnerResponseDTO> LoginPartner(LoginPartnerRequestDTO loginPartnerRequestDTO);

    }
}

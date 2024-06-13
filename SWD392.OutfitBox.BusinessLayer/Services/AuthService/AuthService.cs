using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using SWD392.OutfitBox.BusinessLayer.Exceptions.Auth;
using SWD392.OutfitBox.BusinessLayer.Helpers;
using SWD392.OutfitBox.BusinessLayer.Models.Requests;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using SWD392.OutfitBox.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SWD392.OutfitBox.BusinessLayer.Services.AuthService{
    public class AuthService : IAuthService
    {
        public IMapper _mapper;
        public IUserRepository _userRepository { get; set; }
        public IPartnerRepository _partnerRepository { get; set; }
        public AuthService(IMapper mapper, IUserRepository userRepository, IPartnerRepository partnerRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<LoginSystemResponseDTO> LoginSystem(LoginSystemRequestDTO loginSystemRequestDTO)
        {
            var email = loginSystemRequestDTO.Email?.ToLower().Trim();
            var password = loginSystemRequestDTO.Password;
            var checking = await _userRepository.CheckLogin(email, password);
            if (!checking) return new LoginSystemResponseDTO();
            var user = await _userRepository.GetUserByEmail(email);
            var tokenHandler =  AuthHelper.GetUserToken(user,user.Role.Name);
            return  new LoginSystemResponseDTO()
            { 
              Token= new JwtSecurityTokenHandler().WriteToken(tokenHandler),
              Expiration= tokenHandler.ValidTo
            };
        }
        public async Task<LoginPartnerResponseDTO> LoginPartner(LoginPartnerRequestDTO loginPartnerRequestDTO)
        {
            var email = loginPartnerRequestDTO.Email?.ToLower().Trim();
            var password = loginPartnerRequestDTO.Password;
            var checking = await _partnerRepository.GetPartners(null,null,null,null, email);
            if (checking.IsNullOrEmpty()) return new LoginPartnerResponseDTO();
            var partner = checking.First();
            var tokenHandler = AuthHelper.GetPartnerToken(partner);
            return new LoginPartnerResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenHandler),
                Expiration = tokenHandler.ValidTo
            };
        }
    }
}

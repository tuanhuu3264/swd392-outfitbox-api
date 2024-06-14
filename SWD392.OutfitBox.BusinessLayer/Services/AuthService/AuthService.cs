using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.BusinessLayer.Exceptions.Auth;
using SWD392.OutfitBox.BusinessLayer.Helpers;
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

        public async Task<LoginModel> LoginSystem(string email, string password)
        {
       
            var checking = await _userRepository.CheckLogin(email.ToLower().Trim(), password);
            if (!checking) return new LoginModel();
            var user = await _userRepository.GetUserByEmail(email);
            var tokenHandler =  AuthHelper.GetUserToken(user,user.Role.Name);
            return  new LoginModel()
            { 
              Token= new JwtSecurityTokenHandler().WriteToken(tokenHandler),
              Expiration= tokenHandler.ValidTo
            };
        }
        public async Task<LoginModel> LoginPartner(string email, string password)
        {
            var checking = await _partnerRepository.GetPartners(null,null,null,null, email.ToLower().Trim());
            if (checking.IsNullOrEmpty()) return new LoginModel();
            if(checking.First().Password!=password) return new LoginModel();
            var partner = checking.First();
            var tokenHandler = AuthHelper.GetPartnerToken(partner);
            return new LoginModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenHandler),
                Expiration = tokenHandler.ValidTo
            };
        }
    }
}

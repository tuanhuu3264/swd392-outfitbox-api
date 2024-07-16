using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
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
        public IDatabase _cache;
        public IPartnerRepository _partnerRepository { get; set; }
        public AuthService(IMapper mapper, IUserRepository userRepository, IPartnerRepository partnerRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _partnerRepository = partnerRepository;
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("outfit4rent.online:6379");
            _cache = connectionMultiplexer.GetDatabase();
        }
        public void SaveChangeDeviceTokenPartner(string deviceToken, int id) 
        {
            _cache.StringSet("partner:device-tokens:"+id.ToString(), deviceToken);
        }
        public void LogoutDeleteDeviceTokenUser(int id)
        {
            _cache.StringGetDelete(id.ToString());
        }
        public void LogoutDeleteDeviceTokenPartner(int id)
        {
            _cache.StringGetDelete("partner:device-tokens:" + id.ToString());
        }
        public async Task<LoginModel> LoginSystem(string email, string password)
        {
       
            var checking = await _userRepository.CheckLogin(email.ToLower().Trim(), password);
            if (!checking) return new LoginModel();
            var user = await _userRepository.GetUserByEmail(email);
            var accessTokenHandler =  AuthHelper.GetUserToken(user,user.Role.Name,1);
            var refreshTokenHandler = AuthHelper.GetUserToken(user, user.Role.Name,3);
            return  new LoginModel()
            { 
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshTokenHandler),
                Token = new JwtSecurityTokenHandler().WriteToken(accessTokenHandler),
              Expiration= accessTokenHandler.ValidTo
            };
        }
        public async Task<LoginModel> LoginPartner(string email, string password)
        {
            var checking = await _partnerRepository.GetPartners(null,null,null,null, email.ToLower().Trim());
            if (checking.IsNullOrEmpty()) return new LoginModel();
            if(checking.First().Password!=password) return new LoginModel();
            var partner = checking.First();
            var accessTokenHandler = AuthHelper.GetPartnerToken(partner,1);
            var refreshTokenHandler = AuthHelper.GetPartnerToken(partner, 3);
            return new LoginModel()
            {   
                RefreshToken= new JwtSecurityTokenHandler().WriteToken(refreshTokenHandler),
                Token = new JwtSecurityTokenHandler().WriteToken(accessTokenHandler),
                Expiration = accessTokenHandler.ValidTo
            };
        }
    }
}

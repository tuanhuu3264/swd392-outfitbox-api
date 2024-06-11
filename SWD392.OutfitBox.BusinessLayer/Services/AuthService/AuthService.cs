using AutoMapper;
using FirebaseAdmin.Auth;
using SWD392.OutfitBox.BusinessLayer.Exceptions.Auth;
using SWD392.OutfitBox.BusinessLayer.Helpers;
using SWD392.OutfitBox.BusinessLayer.Models.Requests;

using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using SWD392.OutfitBox.DataLayer.Interfaces;
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
        public ICustomerRepository _customerRepository { get; set; }
        public AuthService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
       
       
    }
}

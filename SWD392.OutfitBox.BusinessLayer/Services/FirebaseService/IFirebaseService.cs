﻿using SWD392.OutfitBox.BusinessLayer.Models.Responses.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.FirebaseService
{
    public interface IFirebaseService
    {
        public Task<LoginResponseDTO> VerifyFirebaseThirdPartToken(string accessToken);
        public Task<LoginResponseDTO> VerifyFirebaseNormalToken(string accessToken);
      
    }
}
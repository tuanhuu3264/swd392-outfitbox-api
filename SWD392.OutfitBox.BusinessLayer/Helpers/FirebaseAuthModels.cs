using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Helpers
{
    public class FirebaseAuthModels
    {
        public string GUID { get; set; } =string.Empty;
        public string Name { get; set; } =string.Empty;
        public string Email {  get; set; } =string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string SignInProvider { get; set; } = string.Empty;
        public bool IsVerify { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

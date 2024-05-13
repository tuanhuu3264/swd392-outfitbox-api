using SWD392.OutfitBox.Core.Constants;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.ProductService
{
    public interface IProductService
    {
        Task<StatusCodeResponse<List<Product>>> GetAll();
    }
}

using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IImageRepository
    {
        Task<bool> UpdateImage(List<Image> images);
     
        Task<Image> GetImageById(int id);

        Task<bool> UpdateListImage(int productId, List<Image> list); 
        
    }

}

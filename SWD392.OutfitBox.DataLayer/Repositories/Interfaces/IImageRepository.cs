﻿using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface IImageRepository
    {
        Task<bool> UpdateImage(List<Image> images);
     
        Task<Image> GetImageById(int id);

        Task<bool> UpdateListImage(int productId, List<Image> list); 

        Task<bool> DeleteImageByProductId(int id);
        Task<Image> CreateImage(Image image);
    }

}

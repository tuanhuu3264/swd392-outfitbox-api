using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(Context context) : base(context)
        {
           
        }

        public async Task<Image> GetImageById(int id)
        {
            var result = await this.Get().FirstOrDefaultAsync(x=>x.ID==id);
            if (result == null) return new Image();
            return result;
        }

        public async Task<bool> UpdateImage(List<Image> images)
        {
            var result =true;
            foreach (var image in images)
            {
                var i = await this.GetById(image.ID);
                if (i == null) await this.AddAsync(image);
                else
                {
                    this.Update(image);
                    if (this.SaveChangesAsync() == null) { return false; }
                }        
            }
            return result;
        }

        public async Task<bool> UpdateListImage(int productid, List<Image> list)
        {
            try {
                var listimg = await this.Get().Where(x => x.IdProduct == productid).ToArrayAsync();
                this.DeleteRange(listimg);
                await this.AddRangeAsync(listimg);
                return true;
            }
            catch {
                return false;
            }
           
        }
        public async Task DeleteImageByProductId(int id)
        {
            var listimg = await this.Get().Where(x => x.IdProduct == id).ToArrayAsync();
            this.DeleteRange(listimg);
        }
    }
}

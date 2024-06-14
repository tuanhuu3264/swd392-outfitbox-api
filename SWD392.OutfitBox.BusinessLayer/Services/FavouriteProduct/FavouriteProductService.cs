using AutoMapper;

using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;

namespace SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct
{
    public class FavouriteProductService : IFavouriteProductService
    {
        public IFavouriteProductRepository _favouriteProductRepository;
        public IMapper _mapper;
        public FavouriteProductService(IMapper mapper, IFavouriteProductRepository favouriteProductRepository)
        {
            _favouriteProductRepository = favouriteProductRepository;
            _mapper = mapper;
        }

        public async Task<FavouriteProductModel> CreateFavouriteProduct(int productId, int customerId)
        {
            var result = await _favouriteProductRepository.CreateFavouriteProductByCustomerIdAndProductId(customerId, productId);
            return _mapper.Map<FavouriteProductModel>(result);
        }

        public async Task<bool> DeleteFavouriteProduct(int productId, int customerId)
        {
            var result = await _favouriteProductRepository.DeleteFavouriteProductByCustomerIdAndProductId(customerId, productId);
            return true;
                } 
    }
}

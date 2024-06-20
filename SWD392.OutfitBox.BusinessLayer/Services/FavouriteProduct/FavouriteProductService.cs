using AutoMapper;

using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.DataLayer.Entities;
using System.Formats.Asn1;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;
using SWD392.OutfitBox.DataLayer.UnitOfWork;

namespace SWD392.OutfitBox.BusinessLayer.Services.FavouriteProduct
{
    public class FavouriteProductService : IFavouriteProductService
    {
        public IFavouriteProductRepository _favouriteProductRepository;
        public IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public FavouriteProductService(IMapper mapper, IFavouriteProductRepository favouriteProductRepository, IUnitOfWork unitOfWork)
        {
            _favouriteProductRepository = favouriteProductRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

       public async Task<List<ProductModel>> GetByCustomerId(int customerId)
        {
           var products = await _favouriteProductRepository.GetFavoritesByCustomerId(customerId);
           var result = _mapper.Map<List<ProductModel>>(products);
            return result;
        }
    }
}

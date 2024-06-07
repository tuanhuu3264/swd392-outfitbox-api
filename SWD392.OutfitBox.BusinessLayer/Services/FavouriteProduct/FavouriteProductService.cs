using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.FavouriteProduct;
using SWD392.OutfitBox.Core.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<CreateFavouriteProductResponseDTO> CreateFavouriteProduct(int productId, int customerId)
        {
            var result = await _favouriteProductRepository.CreateFavouriteProductByCustomerIdAndProductId(customerId, productId);
            return _mapper.Map<CreateFavouriteProductResponseDTO>(result);
        }

        public async Task<DeleteFavouriteProductResponseDTO> DeleteFavouriteProduct(int productId, int customerId)
        {
            var result = await _favouriteProductRepository.DeleteFavouriteProductByCustomerIdAndProductId(customerId, productId);
            return new DeleteFavouriteProductResponseDTO()
            {
                Message = "Delete FavouriteProduct Successfully."
            };
        }
    }
}

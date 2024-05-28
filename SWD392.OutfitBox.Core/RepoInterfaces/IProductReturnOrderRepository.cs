﻿using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.RepoInterfaces
{
    public interface IProductReturnOrderRepository
    {
        public Task<bool> RemoveProductReturnOrderById(int id);
        public Task<ProductReturnOrder> UpdatePoductReturnOrder(ProductReturnOrder productReturnOrder);
        public Task<ProductReturnOrder> GetProductReturnOrderById(int Id);
        public Task<List<ProductReturnOrder>> GetProductsReturnOrder();
        public Task<List<ProductReturnOrder>> CreateProductReturnOrders(ProductReturnOrder[] productReturnOrder);
    }
}

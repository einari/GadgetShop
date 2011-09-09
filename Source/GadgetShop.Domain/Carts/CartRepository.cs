﻿using System;
using GadgetShop.Infrastructure.Entities;
using GadgetShop.Infrastructure.Security;

namespace GadgetShop.Domain.Carts
{
    public class CartRepository : ICartRepository
    {
        IEntityContext<CartItem> _entityContext;
        IUserService _userService;

        public CartRepository(IEntityContext<CartItem> entityContext, IUserService userService)
        {
            _entityContext = entityContext;
            _userService = userService;
        }

        public Cart Get()
        {
            var cart = new Cart();
            return cart;
        }

        public void AddItem(Guid productId, int quantity, double price)
        {
            throw new NotImplementedException();
        }
    }
}
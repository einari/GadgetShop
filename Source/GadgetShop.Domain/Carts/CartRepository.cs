﻿using System;
using System.Linq;
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
            var userId = _userService.GetCurrentUserId();
            var cart = new Cart();
            cart.Items.AddRange(_entityContext.Entities.Where(c => c.UserId == userId));
            return cart;
        }

        public void AddItem(Guid productId, int quantity, double price)
        {
            var cartItem = new CartItem
            {
                UserId = _userService.GetCurrentUserId(),
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = price
            };
            _entityContext.Insert(cartItem);
            
        }


        public void Clear()
        {
            var cart = Get();
            foreach (var item in cart.Items)
                _entityContext.Delete(item);

            _entityContext.Commit();
        }
    }
}

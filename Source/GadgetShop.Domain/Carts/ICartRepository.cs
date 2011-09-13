using System;

namespace GadgetShop.Domain.Carts
{
    public interface ICartRepository
    {
        Cart Get();
        void AddItem(Guid productId, int quantity, double price);
        void Clear();
    }
}

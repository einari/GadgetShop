using System;

namespace GadgetShop.Infrastructure.Entities
{
    public interface IHaveId
    {
        Guid Id { get; }
    }
}

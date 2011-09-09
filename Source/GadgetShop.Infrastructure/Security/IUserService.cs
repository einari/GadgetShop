using System;

namespace GadgetShop.Infrastructure.Security
{
    public interface IUserService
    {
        Guid GetCurrentUserId();
    }
}

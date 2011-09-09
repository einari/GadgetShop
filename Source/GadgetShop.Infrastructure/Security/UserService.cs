using System;
using System.Web;

namespace GadgetShop.Infrastructure.Security
{
    public class UserService : IUserService
    {
        const string CurrentUserKey = "CurrentUser";

        public Guid GetCurrentUserId()
        {
            Guid userId = Guid.Empty;
            var keyFromSession = HttpContext.Current.Session[CurrentUserKey];
            if (keyFromSession != null)
            {
                userId = (Guid)keyFromSession;
            }
            else
            {
                userId = Guid.NewGuid();
                HttpContext.Current.Session[CurrentUserKey] = userId;
            }

            return userId;
        }
    }
}

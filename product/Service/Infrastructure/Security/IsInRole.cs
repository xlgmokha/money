using System.Security.Principal;
using gorilla.commons.utility;

namespace MoMoney.Service.Infrastructure.Security
{
    public class IsInRole : Specification<IPrincipal>
    {
        readonly Role role;

        public IsInRole(Role role)
        {
            this.role = role;
        }

        public bool is_satisfied_by(IPrincipal item)
        {
            return item.IsInRole(role);
        }
    }
}
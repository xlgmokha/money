using System.Security.Principal;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Service.Infrastructure.Security
{
    public class IsInRole : ISpecification<IPrincipal>
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
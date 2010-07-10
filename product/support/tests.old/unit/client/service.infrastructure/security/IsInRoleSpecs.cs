using System.Security.Principal;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Security;

namespace tests.unit.client.service.infrastructure.security
{
    public class IsInRoleSpecs
    {
        public class when_checking_if_a_principal_belongs_to_a_role :
            TestsFor<Specification<IPrincipal>>
        {
            static protected readonly Role administrator_role = new Role("administrators");

            public override Specification<IPrincipal> create_sut()
            {
                return new IsInRole(administrator_role);
            }
        }

        public class when_not_in_one_of_the_roles : when_checking_if_a_principal_belongs_to_a_role
        {
            context c = () =>
            {
                principal = dependency<IPrincipal>();
                principal
                    .is_told_to(x => x.IsInRole(administrator_role))
                    .it_will_return(false);
            };

            because b = () =>
            {
                result = sut.is_satisfied_by(principal);
            };

            it should_return_false = () => result.should_be_false();

            static bool result;
            static IPrincipal principal;
        }

        public class when_in_one_of_the_roles : when_checking_if_a_principal_belongs_to_a_role
        {
            context c = () =>
            {
                principal = dependency<IPrincipal>();
                principal
                    .is_told_to(x => x.IsInRole(administrator_role))
                    .it_will_return(true);
            };

            because b = () =>
            {
                result = sut.is_satisfied_by(principal);
            };

            it should_return_true = () => result.should_be_true();

            static bool result;
            static IPrincipal principal;
        }
    }
}
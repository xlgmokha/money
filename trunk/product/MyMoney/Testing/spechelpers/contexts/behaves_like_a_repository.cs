using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.DataAccess.core;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.transactions2;
using MoMoney.Testing.MetaData;

namespace MoMoney.Testing.spechelpers.contexts
{
    [RunInRealContainer]
    [Concern(typeof (IDatabaseGateway))]
    public abstract class behaves_like_a_repository : concerns_for<IDatabaseGateway>
    {
        public override IDatabaseGateway create_sut()
        {
            return resolve.dependency_for<IDatabaseGateway>();
        }

        context c = () =>
                        {
                            session = resolve.dependency_for<ISessionFactory>().create();
                            resolve.dependency_for<IContext>().add(resolve.dependency_for<IKey<ISession>>(), session);
                        };

        after_each_observation after = () => session.Dispose();

        static ISession session;
    }
}
using System;
using developwithpassion.bdd.contexts;
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
            Console.Out.WriteLine("create sut");
            return resolve.dependency_for<IDatabaseGateway>();
        }

        context c = () =>
                        {
                            //};
                            //before_each_observation before =
                            //    () =>
                            //        {
                            session = resolve.dependency_for<ISessionFactory>().create();
                            resolve.dependency_for<IContext>().add(resolve.dependency_for<IKey<ISession>>(), session);
                            Console.Out.WriteLine("before each");
                        };

        after_each_observation after =
            () =>
                {
                    session.Dispose();
                    Console.Out.WriteLine("after each");
                };

        static ISession session;
    }
}
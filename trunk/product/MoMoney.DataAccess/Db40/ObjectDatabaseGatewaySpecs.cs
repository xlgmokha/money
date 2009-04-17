using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.DataAccess.core;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.transactions2;

namespace MoMoney.DataAccess.db40
{
    [Concern(typeof (ObjectDatabaseGateway))]
    public abstract class behaves_like_a_object_repository : concerns_for<IDatabaseGateway, ObjectDatabaseGateway>
    {
        context c = () =>
                        {
                            context = the_dependency<ISessionContext>();
                            provider = the_dependency<ISessionProvider>();
                        };

        protected static ISessionContext context;
        protected static ISessionProvider provider;
    }

    public class when_loading_all_the_items_from_the_database : behaves_like_a_object_repository
    {
        it should_return_all_the_items_from_the_database = () =>
                                                               {
                                                                   result.should_contain(first_item);
                                                                   result.should_contain(second_item);
                                                               };

        context c = () =>
                        {
                            first_item = an<IEntity>();
                            second_item = an<IEntity>();
                            var session = an<Infrastructure.transactions2.ISession>();

                            //context.is_told_to(x => x.current_session()).it_will_return(session);
                            //session.is_told_to(x => x.query<IEntity>()).it_will_return(new List<IEntity> {first_item, second_item});


                            provider.is_told_to(x => x.get_the_current_session()).it_will_return(session);
                            when_the(session).is_told_to(x => x.all<IEntity>()).it_will_return(first_item, second_item);
                        };

        because b = () => { result = sut.all<IEntity>(); };

        static IEnumerable<IEntity> result;
        static IEntity first_item;
        static IEntity second_item;
    }
}
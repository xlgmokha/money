using System.Collections.Generic;
using Db4objects.Db4o;
using developwithpassion.bdd.contexts;
using MoMoney.DataAccess.core;
using MoMoney.Domain.Core;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.DataAccess.db40
{
    [Concern(typeof (ObjectDatabaseGateway))]
    public abstract class behaves_like_a_object_repository : concerns_for<IDatabaseGateway, ObjectDatabaseGateway>
    {
        context c = () => { _provider = the_dependency<ISessionProvider>(); };

        protected static ISessionProvider _provider;
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
                            var session = an<IObjectContainer>();

                            _provider.is_told_to(x => x.get_session()).it_will_return(session);
                            session.is_told_to(x => x.Query<IEntity>()).it_will_return(new List<IEntity>
                                                                                           {first_item, second_item});
                        };

        because b = () => { result = sut.all<IEntity>(); };

        static IEnumerable<IEntity> result;
        static IEntity first_item;
        static IEntity second_item;
    }
}
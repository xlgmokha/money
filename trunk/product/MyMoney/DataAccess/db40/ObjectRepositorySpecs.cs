using System.Collections.Generic;
using Db4objects.Db4o;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.Core;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

namespace MyMoney.DataAccess.db40
{
    [Concern(typeof (ObjectRepository))]
    public abstract class behaves_like_a_object_repository : concerns_for<IRepository, ObjectRepository>
    {
        public override IRepository create_sut()
        {
            return new ObjectRepository(factory);
        }

        context c = () => { factory = the_dependency<ISessionFactory>(); };

        protected static ISessionFactory factory;
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

                            factory.is_told_to(x => x.create()).it_will_return(session);
                            session.is_told_to(x => x.Query<IEntity>()).it_will_return(new List<IEntity> {first_item, second_item});
                        };

        because b = () => { result = sut.all<IEntity>(); };

        static IEnumerable<IEntity> result;
        static IEntity first_item;
        static IEntity second_item;
    }
}
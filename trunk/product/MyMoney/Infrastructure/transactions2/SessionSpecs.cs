using System;
using developwithpassion.bdd.contexts;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.caching;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.transactions2
{
    public class SessionSpecs
    {
    }

    public class behaves_like_session : concerns_for<ISession, Session>
    {
        context c = () => { factory = the_dependency<IIdentityMapFactory>(); };

        protected static IIdentityMapFactory factory;
    }

    public class when_saving_an_item_to_a_session : behaves_like_session
    {
        it should_add_the_entity_to_the_identity_map = () => map.was_told_to(x => x.add(guid, entity));

        context c = () =>
                        {
                            guid = Guid.NewGuid();
                            entity = an<ITestEntity>();
                            map = an<IIdentityMap<Guid, ITestEntity>>();

                            when_the(entity).is_told_to(x => x.Id).it_will_return(guid);
                            when_the(factory).is_told_to(x => x.create_for<ITestEntity>()).it_will_return(map);
                        };

        because b = () => { sut.save(entity); };

        static ITestEntity entity;
        static IIdentityMap<Guid, ITestEntity> map;
        static Guid guid;
    }

    public interface ITestEntity : IEntity
    {
    }
}
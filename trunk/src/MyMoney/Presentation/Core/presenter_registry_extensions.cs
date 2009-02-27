using System;
using System.Collections.Generic;
using System.Linq;
using MyMoney.Domain.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Core
{
    public static class presenter_registry_extensions
    {
        public static IEnumerable<Presenter> all_implementations_of<Presenter>(this IRegistry<IPresenter> repository)
            where Presenter : IPresenter
        {
            return repository
                .all()
                .Where(p => p.is_an_implementation_of<Presenter>())
                .Select(p => p.downcast_to<Presenter>());
        }

        public static Presenter find_an_implementation_of<Presenter>(this IRegistry<IPresenter> registry)
            where Presenter : IPresenter
        {
            try
            {
                return registry
                    .all()
                    .Single(p => p.is_an_implementation_of<Presenter>())
                    .downcast_to<Presenter>();
            }
            catch (Exception exception)
            {
                throw new could_not_find_presenter<Presenter>(exception);
            }
        }
    }
}
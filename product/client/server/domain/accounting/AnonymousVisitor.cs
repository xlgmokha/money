using System;
using gorilla.commons.utility;

namespace presentation.windows.server.domain.accounting
{
    public class AnonymousVisitor<T> : Visitor<T>
    {
        readonly Action<T> action;

        public AnonymousVisitor(Action<T> action)
        {
            this.action = action;
        }

        public void visit(T item_to_visit)
        {
            action(item_to_visit);
        }
    }
}
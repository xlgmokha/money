using System;

namespace MoMoney.boot.container.registration.mapping
{
    public class DelegateTargetAction<Destination, Value> : ITargetAction<Destination, Value>
    {
        private readonly Action<Destination, Value> action;

        public DelegateTargetAction(Action<Destination, Value> action)
        {
            this.action = action;
        }

        public void act_against(Destination destination, Value value)
        {
            action(destination, value);
        }
    }
}
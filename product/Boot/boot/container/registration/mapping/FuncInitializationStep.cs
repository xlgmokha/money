using System;

namespace MoMoney.boot.container.registration.mapping
{
    public class FuncInitializationStep<Destination> : IMapInitializationStep<Destination>
    {
        readonly Func<Destination> func;

        public FuncInitializationStep(Func<Destination> func)
        {
            this.func = func;
        }

        public Destination initialize()
        {
            return func();
        }
    }
}
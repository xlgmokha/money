using System;

namespace MoMoney.boot.container.registration.mapping
{
    public class MissingInitializationStep<Output> : IMapInitializationStep<Output>
    {
        public Output initialize()
        {
            throw new ArgumentException("A map must be provided an initialization step before it can be used to map");
        }
    }
}
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Tasks.infrastructure.core
{
    public interface ICallbackCommand<T> : IParameterizedCommand<ICallback<T>>
    {
    }
}
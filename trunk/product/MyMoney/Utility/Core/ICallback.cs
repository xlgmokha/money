namespace MoMoney.Utility.Core
{
    public interface ICallback : ICommand
    {
    }

    public interface ICallback<T> : IParameterizedCommand<T>
    {
    }
}
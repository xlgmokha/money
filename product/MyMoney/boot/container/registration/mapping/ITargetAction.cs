namespace MoMoney.boot.container.registration.mapping
{
    public interface ITargetAction<Target, ValueType>
    {
        void act_against(Target destination, ValueType value);
    }
}
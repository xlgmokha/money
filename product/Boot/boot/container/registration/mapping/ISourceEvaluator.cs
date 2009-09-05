namespace MoMoney.boot.container.registration.mapping
{
    public interface ISourceEvaluator<Source, Result>
    {
        Result evaluate_against(Source source);
    }
}
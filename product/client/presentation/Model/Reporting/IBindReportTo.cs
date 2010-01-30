using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.reporting
{
    public interface IBindReportTo<T, TQuery> : IReport, ParameterizedCommand<T> where TQuery : Query<T> {}
}
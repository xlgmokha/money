using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.reporting
{
    public interface IBindReportTo<T, Query> : IReport, ParameterizedCommand<T> where Query : Query<T> {}
}
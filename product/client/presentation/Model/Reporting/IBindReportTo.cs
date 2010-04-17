using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.reporting
{
    public interface IBindReportTo<T, TQuery> : IReport, Command<T> where TQuery : Query<T> {}
}
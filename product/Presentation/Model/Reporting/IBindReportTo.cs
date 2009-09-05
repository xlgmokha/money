using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Model.reporting
{
    public interface IBindReportTo<T, Query> : IReport, IParameterizedCommand<T> where Query : IQuery<T>
    {
    }
}
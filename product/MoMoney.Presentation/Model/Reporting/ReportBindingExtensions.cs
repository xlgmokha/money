using System;
using System.Linq.Expressions;
using DataDynamics.ActiveReports;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Model.reporting
{
    public static class ReportBindingExtensions
    {
        public static void bind_to<T, K>(this ARControl control, Expression<Func<T, K>> func)
        {
            if (func.Body.is_an_implementation_of<MemberExpression>()) {
                control.DataField = func.Body.downcast_to<MemberExpression>().Member.Name;
            }
            else {
                control.DataField = func.Body.downcast_to<UnaryExpression>().Method.Name;
            }
        }
    }
}
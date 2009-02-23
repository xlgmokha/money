using System;
using System.Linq.Expressions;
using DataDynamics.ActiveReports;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Model.reporting
{
    public static class report_binding_extensions
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
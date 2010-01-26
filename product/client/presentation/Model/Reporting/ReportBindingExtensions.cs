using System;
using System.Linq.Expressions;
using DataDynamics.ActiveReports;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.reporting
{
    static public class ReportBindingExtensions
    {
        static public void bind_to<T, K>(this ARControl control, Expression<Func<T, K>> func)
        {
            if (func.Body.is_an_implementation_of<MemberExpression>())
            {
                control.DataField = func.Body.downcast_to<MemberExpression>().Member.Name;
            }
            else
            {
                control.DataField = func.Body.downcast_to<UnaryExpression>().Method.Name;
            }
        }
    }
}
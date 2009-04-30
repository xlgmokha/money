using System;
using System.Linq.Expressions;

namespace MoMoney.boot.container.registration.mapping
{
    public class ExpressionSourceEvaluator<Input, Result> : ISourceEvaluator<Input, Result>
    {
        private readonly Expression<Func<Input, Result>> original_expression;
        private Func<Input, Result> evaluator_expression;

        public ExpressionSourceEvaluator(Expression<Func<Input, Result>> original_expression)
        {
            this.original_expression = original_expression;
        }

        public Result evaluate_against(Input input)
        {
            initialize_evaluator();
            return evaluator_expression(input);
        }

        private void initialize_evaluator()
        {
            if (evaluator_expression != null) return;
            evaluator_expression = original_expression.Compile();
        }
    }
}
using developwithpassion.bdd.contexts;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;
using MoMoney.Utility.Core;

namespace MoMoney.Utility.Extensions
{
    public class when_evaluating_two_conditions : concerns
    {
        context c = () =>
                        {
                            left = an<ISpecification<int>>();
                            right = an<ISpecification<int>>();
                        };

        protected static ISpecification<int> left;
        protected static ISpecification<int> right;
    }

    public class when_checking_if_two_conditions_are_met_and_they_are : when_evaluating_two_conditions
    {
        it should_return_true = () => result.should_be_true();

        context c = () =>
                        {
                            when_the(right).is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
                            when_the(left).is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
                        };

        because b = () => { result = left.or(right).is_satisfied_by(1); };

        static bool result;
    }

    public class when_checking_if_one_of_two_conditions_are_met_and_the_left_one_is_not : when_evaluating_two_conditions
    {
        it should_return_true = () => result.should_be_true();

        context c = () =>
                        {
                            when_the(right).is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
                            when_the(left).is_told_to(x => x.is_satisfied_by(1)).it_will_return(false);
                        };

        because b = () => { result = left.or(right).is_satisfied_by(1); };

        static bool result;
    }

    public class when_checking_if_one_of_two_conditions_are_met_and_the_right_one_is_not : when_evaluating_two_conditions
    {
        it should_return_true = () => result.should_be_true();

        context c = () =>
                        {
                            when_the(right).is_told_to(x => x.is_satisfied_by(1)).it_will_return(false);
                            when_the(left).is_told_to(x => x.is_satisfied_by(1)).it_will_return(true);
                        };

        because b = () => { result = left.or(right).is_satisfied_by(1); };

        static bool result;
    }
}
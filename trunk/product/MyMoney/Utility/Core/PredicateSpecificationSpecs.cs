using developwithpassion.bdd.contexts;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Utility.Core
{
    [Concern(typeof (PredicateSpecification<>))]
    public class when_checking_if_a_criteria_is_met_and_it_is : concerns
    {
        it should_return_true = () => new PredicateSpecification<int>(x => true).is_satisfied_by(1).should_be_true();
    }

    [Concern(typeof (PredicateSpecification<>))]
    public class when_checking_if_a_criteria_is_met_and_it_is_not : concerns
    {
        it should_return_true = () => new PredicateSpecification<int>(x => false).is_satisfied_by(1).should_be_false();
    }
}
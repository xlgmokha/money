using jpboodhoo.bdd.contexts;
using MyMoney.Domain.Core;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Infrastructure.transactions
{
    public abstract class behaves_like_unit_of_work_registration : concerns_for<IUnitOfWorkRegistration<Pillow>>
    {
        public override IUnitOfWorkRegistration<Pillow> create_sut()
        {
            return new UnitOfWorkRegistration<Pillow>(new Pillow("pink"), new Pillow("yellow"));
        }
    }

    public class when_comparing_the_current_instance_of_a_component_with_its_original_and_it_has_changes :
        behaves_like_unit_of_work_registration
    {
        it should_indicate_that_there_are_changes = () => result.should_be_true();

        because b = () => { result = sut.contains_changes(); };

        static bool result;
    }

    public class Pillow : Entity<Pillow>
    {
        readonly string color;

        public Pillow(string color)
        {
            this.color = color;
        }
    }
}
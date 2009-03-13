using developwithpassion.bdd.contexts;
using MoMoney.Domain.Core;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.transactions
{
    public abstract class behaves_like_unit_of_work_registration : concerns_for<IUnitOfWorkRegistration<Pillow>>
    {
    }

    public class when_comparing_the_current_instance_of_a_component_with_its_original_and_it_has_changes :
        behaves_like_unit_of_work_registration
    {
        it should_indicate_that_there_are_changes = () => result.should_be_true();

        because b = () => { result = sut.contains_changes(); };

        public override IUnitOfWorkRegistration<Pillow> create_sut()
        {
            return new UnitOfWorkRegistration<Pillow>(new Pillow("pink"), new Pillow("yellow"));
        }

        static bool result;
    }

    public class when_the_original_instance_has_a_null_field_that_is_now_not_null :
        behaves_like_unit_of_work_registration
    {
        it should_indicate_that_there_are_changes = () => result.should_be_true();

        because b = () => { result = sut.contains_changes(); };

        public override IUnitOfWorkRegistration<Pillow> create_sut()
        {
            return new UnitOfWorkRegistration<Pillow>(new Pillow(null), new Pillow("yellow"));
        }

        static bool result;
    }

    public class when_the_original_instance_had_a_non_null_field_and_the_current_instance_has_a_null_field :
        behaves_like_unit_of_work_registration
    {
        it should_indicate_that_there_are_changes = () => result.should_be_true();

        because b = () => { result = sut.contains_changes(); };

        public override IUnitOfWorkRegistration<Pillow> create_sut()
        {
            return new UnitOfWorkRegistration<Pillow>(new Pillow("green"), new Pillow(null));
        }

        static bool result;
    }

    public class when_the_original_instance_has_the_same_value_as_the_current_instance :
        behaves_like_unit_of_work_registration
    {
        it should_indicate_that_there_are_no_changes = () => result.should_be_false();

        because b = () => { result = sut.contains_changes(); };

        public override IUnitOfWorkRegistration<Pillow> create_sut()
        {
            return new UnitOfWorkRegistration<Pillow>(new Pillow("green"), new Pillow("green"));
        }

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
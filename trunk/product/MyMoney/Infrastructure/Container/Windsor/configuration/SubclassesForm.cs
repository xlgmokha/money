using System;
using System.Windows.Forms;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public class SubclassesForm : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type item)
        {
            return typeof (Form).IsAssignableFrom(item);
        }
    }
}
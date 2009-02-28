using System;
using System.Windows.Forms;

namespace MyMoney.Infrastructure.Container.Windsor.configuration
{
    public class SubclassesForm : IComponentExclusionSpecification
    {
        public bool is_satisfied_by(Type item)
        {
            return item.IsSubclassOf(typeof (Form));
        }
    }
}
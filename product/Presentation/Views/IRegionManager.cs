using System;
using System.ComponentModel;

namespace momoney.presentation.views
{
    public interface IRegionManager
    {
        void region<Control>(Action<Control> action) where Control : IComponent;
    }
}
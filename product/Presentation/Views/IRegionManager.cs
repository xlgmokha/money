using System;
using System.ComponentModel;

namespace momoney.presentation.views
{
    public interface IRegionManager
    {
        void region<T>(Action<T> action) where T : IComponent;
    }
}
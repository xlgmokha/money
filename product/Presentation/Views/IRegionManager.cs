using System;
using System.ComponentModel;

namespace MoMoney.Presentation.Views.Shell
{
    public interface IRegionManager
    {
        void region<T>(Action<T> action) where T : IComponent;
    }
}
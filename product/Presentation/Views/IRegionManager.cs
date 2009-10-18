using System;
using System.ComponentModel;

namespace MoMoney.Presentation.Views
{
    public interface IRegionManager
    {
        void region<T>(Action<T> action) where T : IComponent;
    }
}
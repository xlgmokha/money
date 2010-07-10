using System;
using System.Windows;

namespace presentation.windows
{
    public interface RegionManager
    {
        void region<Control>(Action<Control> configure) where Control : UIElement;
    }
}
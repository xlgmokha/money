using System;
using System.ComponentModel;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.core
{
    public interface IDockedContentView : IDockContent, IView
    {
        void add_to(DockPanel panel);
    }
}
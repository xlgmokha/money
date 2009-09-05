using System;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Windows.Forms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public interface ITreeBranch
    {
        void accept(IVisitor<ITreeBranch> visitor);
        ITreeBranch add_child(string name, ApplicationIcon icon, ICommand command);
        ITreeBranch add_child(string name, ApplicationIcon icon, Action command);
    }
}
using System;
using gorilla.commons.utility;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public interface ITreeBranch
    {
        void accept(Visitor<ITreeBranch> visitor);
        ITreeBranch add_child(string name, ApplicationIcon icon, Command command);
        ITreeBranch add_child(string name, ApplicationIcon icon, Action command);
    }
}
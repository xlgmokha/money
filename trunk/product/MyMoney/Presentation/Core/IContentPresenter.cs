using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Core
{
    public interface IContentPresenter : IPresenter
    {
        IDockedContentView View { get; }
    }
}
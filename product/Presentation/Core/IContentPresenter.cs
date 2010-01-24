using momoney.presentation.views;

namespace MoMoney.Presentation.Core
{
    public interface IContentPresenter : IPresenter
    {
        IDockedContentView View { get; }
    }
}
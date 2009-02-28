using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Core
{
    public interface IContentPresenter : IPresenter
    {
        IDockedContentView View { get; }
    }
}
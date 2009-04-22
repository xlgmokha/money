using System.Collections.Generic;
using Gorilla.Commons.Infrastructure;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Service.Application;
using MoMoney.Tasks.application;

namespace MoMoney.Presentation.Presenters
{
    public interface IAddCompanyPresenter : IContentPresenter
    {
        void submit(RegisterNewCompany dto);
    }

    public class AddCompanyPresenter : ContentPresenter<IAddCompanyView>, IAddCompanyPresenter
    {
        readonly ICommandPump pump;

        public AddCompanyPresenter(IAddCompanyView view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void run()
        {
            view.attach_to(this);
            pump.run<IEnumerable<CompanyDTO>, IGetAllCompanysQuery>(view);
        }

        public void submit(RegisterNewCompany dto)
        {
            pump
                .run<IRegisterNewCompanyCommand, RegisterNewCompany>(dto)
                .run<IEnumerable<CompanyDTO>, IGetAllCompanysQuery>(view);
        }
    }
}
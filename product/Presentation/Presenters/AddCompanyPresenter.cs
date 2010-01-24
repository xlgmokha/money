using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters
{
    public class AddCompanyPresenter : ContentPresenter<IAddCompanyView>
    {
        readonly ICommandPump pump;

        public AddCompanyPresenter(IAddCompanyView view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void present()
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
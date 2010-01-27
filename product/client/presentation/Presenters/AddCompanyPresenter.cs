using System.Collections.Generic;
using Gorilla.Commons.Infrastructure.Logging;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters
{
    public class AddCompanyPresenter : TabPresenter<IAddCompanyView>
    {
        readonly ICommandPump pump;

        public AddCompanyPresenter(IAddCompanyView view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        protected override void present()
        {
            pump.run<IEnumerable<CompanyDTO>, IGetAllCompanysQuery>(view);
        }

        public void submit(RegisterNewCompany dto)
        {
            this.log().debug("registering a new company: {0}", dto.company_name);
            pump.run<IRegisterNewCompanyCommand, RegisterNewCompany>(dto);
            pump.run<IEnumerable<CompanyDTO>, IGetAllCompanysQuery>(view);
        }
    }
}
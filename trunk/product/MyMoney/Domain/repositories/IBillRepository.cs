using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;

namespace MoMoney.Domain.repositories
{
    public interface IBillRepository
    {
        IEnumerable<IBill> all();
    }
}
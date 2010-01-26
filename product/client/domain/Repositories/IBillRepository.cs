using System.Collections.Generic;
using MoMoney.Domain.Accounting;

namespace MoMoney.Domain.repositories
{
    public interface IBillRepository
    {
        IEnumerable<Bill> all();
    }
}
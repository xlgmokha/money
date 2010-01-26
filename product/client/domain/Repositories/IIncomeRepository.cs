using System.Collections.Generic;
using MoMoney.Domain.Accounting;

namespace MoMoney.Domain.repositories
{
    public interface IIncomeRepository
    {
        IEnumerable<Income> all();
    }
}
using System.Collections.Generic;
using MoMoney.Domain.Accounting.Growth;

namespace MoMoney.Domain.repositories
{
    public interface IIncomeRepository
    {
        IEnumerable<IIncome> all();
    }
}
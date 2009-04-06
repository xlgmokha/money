using System.Collections.Generic;
using MoMoney.Domain.accounting.financial_growth;

namespace MoMoney.Domain.repositories
{
    public interface IIncomeRepository
    {
        IEnumerable<IIncome> all();
    }
}
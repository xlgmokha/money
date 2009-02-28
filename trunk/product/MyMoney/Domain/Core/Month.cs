using System;

namespace MyMoney.Domain.Core
{
    public interface IMonth
    {
        bool represents(DateTime date);
    }
}
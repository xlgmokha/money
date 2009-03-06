using System;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Core
{
    public class could_not_find_presenter<T> : Exception
    {
        public could_not_find_presenter(Exception e)
            : base("Could Not Find an implementation of".formatted_using(typeof (T)), e)
        {
        }
    }
}
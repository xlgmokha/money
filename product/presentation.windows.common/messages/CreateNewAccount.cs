using System;

namespace presentation.windows.common.messages
{
    [Serializable]
    public class CreateNewAccount
    {
        public string account_name { get; set; }
        public string currency { get; set; }
    }
}
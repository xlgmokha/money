using System;
using presentation.windows.common;

namespace presentation.windows.events
{
    public class SelectedFamilyMember : IEvent
    {
        public Guid id { get; set; }
    }
}
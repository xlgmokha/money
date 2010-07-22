using System;
using gorilla.commons.utility;

namespace presentation.windows.presenters
{
    public class PersonDetails
    {
        public Guid id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public override string ToString()
        {
            return "{0} {1}".format(first_name, last_name);
        }
    }
}
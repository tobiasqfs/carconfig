using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigurator.de.qfs.model.exceptions
{
    class ContactDetailsException : Exception
    {
        public ContactDetailsException() : base() { }
        public ContactDetailsException(string s) : base(s) { }
        public ContactDetailsException(string s, Exception e) : base(s, e) { }
    }
}

using System;

namespace CarConfigurator.de.qfs.model.exceptions
{
    class InvalidPriceException : Exception
    {
        public InvalidPriceException() : base() { }
        public InvalidPriceException(string s) : base(s) { }
        public InvalidPriceException(string s, Exception e) : base(s, e) { }
    }
}

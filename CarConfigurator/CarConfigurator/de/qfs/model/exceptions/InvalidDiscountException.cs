using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigurator.de.qfs.model.exceptions
{
    class InvalidDiscountException : Exception
    {
        public InvalidDiscountException() : base() { }
        public InvalidDiscountException(string s) : base(s) { }
        public InvalidDiscountException(string s, Exception e) : base(s, e) { }
    }
}

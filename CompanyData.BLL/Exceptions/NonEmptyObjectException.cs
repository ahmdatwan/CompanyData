using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.BLL.Exceptions
{
    public class NonEmptyObjectException : Exception
    {
        public NonEmptyObjectException() : base() { }
        public NonEmptyObjectException(string message) : base(message) { }
        public NonEmptyObjectException(string message, Exception inner) : base(message, inner) { }
    }
}

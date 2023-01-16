using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaGIT
{
    public class DayException : Exception
    {
        public DayException() { }
        public DayException(string message) : base(message) { }
    }
}

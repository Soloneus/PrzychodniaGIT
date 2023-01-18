using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaGIT
{
    [DataContract]
    public class DataException : Exception
    {
        public DataException() { }
        public DataException(string message) : base(message) { }
    }
}

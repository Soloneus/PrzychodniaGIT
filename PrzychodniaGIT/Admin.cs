using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaGIT
{
    [DataContract]
    public class Admin
    {
        [DataMember]
        public static string login = "ADMIN";
        [DataMember]
        public static string haslo = "ADMIN";
    }
}


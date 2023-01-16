using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PrzychodniaGIT;

namespace PrzychodniaGIT
{
    [DataContract(IsReference = true)]
    public class Diagnoza
    {
        Wizyta wizyta;
        string choroba;
        string recepta;

        [DataMember]
        public Wizyta Wizyta { get => wizyta; set => wizyta = value; }

        [DataMember]
        public string Choroba { get => choroba; set => choroba = value; }

        [DataMember]
        public string Recepta { get => recepta; set => recepta = value; }

        public Diagnoza()
        {
            Wizyta = new();
            choroba = string.Empty;
            recepta = string.Empty;
        }
        public Diagnoza(Wizyta wizyta, string choroba, string recepta) : this()
        {
            Wizyta = wizyta;
            Choroba = choroba;
            Recepta = recepta;
        }

        public override string ToString()
        {
            return $"Dzień: {Wizyta.Data:dd-MM-yyyy}, Diagnoza: {Choroba}, Recepta: {Recepta}";
        }
    }
}
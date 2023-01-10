using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrzychodniaGIT;

namespace PrzychodniaGIT
{
    public class Diagnoza
    {
        Wizyta wizyta;
        string choroba;
        string recepta;

        public Wizyta Wizyta { get => wizyta; set => wizyta = value; }
        public string Choroba { get => choroba; set => choroba = value; }
        public string Recepta { get => recepta; set => recepta = value; }

        public Diagnoza(Wizyta wizyta, string choroba, string recepta)
        {
            Wizyta = wizyta;
            Choroba = choroba;
            Recepta = recepta;
        }

        public override string ToString()
        {
            return $"Dzień: {Wizyta.DataOd:dd-MM-yyyy}, Diagnoza: {Choroba}, Recepta: {Recepta}";
        }
    }
}
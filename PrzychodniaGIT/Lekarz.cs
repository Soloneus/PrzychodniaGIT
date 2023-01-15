using PrzychodniaGIT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaGIT
{

    [DataContract]
    public class Lekarz : Osoba
    {

        string specjalizacja;
        Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>> godzinyPracy;

        [DataMember]
        public string Specjalizacja { get => specjalizacja; set => specjalizacja = value; }

        [DataMember]
        public Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>> GodzinyPracy { get => godzinyPracy; set => godzinyPracy = value; }

        public Lekarz()
        {
            Specjalizacja = string.Empty;
            GodzinyPracy = new();
        }

        public Lekarz(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec,
            string specjalizacja, string hasło, Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>> godzinyPracy) : base(imie, nazwisko, dataUrodzenia, pesel, plec, hasło)
        {
            Specjalizacja = specjalizacja;
            GodzinyPracy = godzinyPracy;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<DayOfWeek, Tuple<TimeSpan, TimeSpan>> dzien in GodzinyPracy)
            {
                sb.AppendLine($"{dzien.Key.ToString()}: {dzien.Value.Item1.ToString()[0..5]}-{dzien.Value.Item2.ToString()[0..5]}");
            }
            return $"{Imie} {Nazwisko}, Specjalizacja: {Specjalizacja}\n{sb}";
        }

    }
}
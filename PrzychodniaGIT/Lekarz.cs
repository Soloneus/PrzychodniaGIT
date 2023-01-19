using PrzychodniaGIT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaGIT
{

    [DataContract]
    public class Lekarz : Osoba, ICloneable
    {

        string specjalizacja;
        Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>> godzinyPracy;
        Dictionary<Tuple<DateTime, TimeSpan>, bool> zaplanowane_Wizyty;


        [DataMember]
        public string Specjalizacja { get => specjalizacja; set => specjalizacja = value; }

        [DataMember]
        public Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>> GodzinyPracy { get => godzinyPracy; set => godzinyPracy = value; }

        [DataMember]
        public Dictionary<Tuple<DateTime, TimeSpan>, bool> Zaplanowane_Wizyty { get => zaplanowane_Wizyty; set => zaplanowane_Wizyty = value; }

        public Lekarz()
        {
            Specjalizacja = string.Empty;
            GodzinyPracy = new();
            zaplanowane_Wizyty = new();
        }

        public Lekarz(string imie, string nazwisko, string dataUrodzenia, string pesel, EnumPlec plec,
            string specjalizacja, Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>> godzinyPracy) : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            Specjalizacja = specjalizacja;
            GodzinyPracy = godzinyPracy;
            zaplanowane_Wizyty = new();
        }

        public bool SprawdzCzyMoznaUmowic(string data, TimeSpan godzina)
        {

            if (Zaplanowane_Wizyty == null)
            {
                return true;
            }

            if (!DateTime.TryParseExact(data,
                new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" ,"yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd"
                }, null, System.Globalization.DateTimeStyles.None,
                out DateTime res))
            {
                throw new ArgumentException("Zła data");
            }

            if (res < DateTime.Now) { return false; }

            DayOfWeek dzien = res.DayOfWeek;
            if (GodzinyPracy.ContainsKey(dzien))
            {
                Tuple<TimeSpan, TimeSpan> godzinyPrzyjec = GodzinyPracy[dzien];
                if ((godzina.Hours >= godzinyPrzyjec.Item1.Hours && godzina.Hours <= godzinyPrzyjec.Item2.Hours) && (godzina.Minutes == 0 || godzina.Minutes == 30))
                {
                    // sprawdzenie czy w tej godzinie jest już zaplanowana wizyta
                    if (Zaplanowane_Wizyty.ContainsKey(Tuple.Create(DateTime.Parse(data), godzina)))
                    {
                        if (Zaplanowane_Wizyty[Tuple.Create(DateTime.Parse(data), godzina)])
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
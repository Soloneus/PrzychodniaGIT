using PrzychodniaGIT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
//sprawdzic czy lekarz moze przyjac ludzi - lambda w diagnoza
//interfejsy
namespace PrzychodniaGIT
{
    [DataContract]
    public class Wizyta : IComparable<Wizyta>
    {
        DateTime data;
        Lekarz lekarz;
        Pacjent pacjent;
        TimeSpan godzina;

        [DataMember]
        public DateTime Data { get => data; set => data = value; }
        [DataMember]
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        [DataMember]
        public Pacjent Pacjent { get => pacjent; set => pacjent = value; }

        [DataMember]
        public TimeSpan Godzina { get => godzina; set => godzina = value; }

        public Wizyta()
        {
            Lekarz = new Lekarz();
            Pacjent = new Pacjent();
            Data = new DateTime();
            Godzina = new TimeSpan();
        }
        public Wizyta(string data, Lekarz lekarz, Pacjent pacjent, TimeSpan godzina) : this()
        {
            if (!DateTime.TryParseExact(data,
                new string[] { "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" ,"yyyy.MM.dd", "yyyy/MM/dd", "yyyy-MM-dd"
                }, null, System.Globalization.DateTimeStyles.None,
                out DateTime res))
            {
                throw new DataException("Zły format daty!");
            }
            Data = res;
            Lekarz = lekarz;
            Pacjent = pacjent;
            Godzina = godzina;
        }


        public override string ToString()
        {
            return $"Pacjent: {pacjent.Imie} {pacjent.Nazwisko} ({pacjent.Pesel})\nLekarz: {lekarz.Imie} {lekarz.Nazwisko} ({lekarz.Pesel})" +
                $"\nData: {Data:dd-MM-yyyy} {Godzina.Hours:00}:{Godzina.Minutes:00}\n";
        }

        public int CompareTo(Wizyta? other)
        {
            if (other == null) return 1;
            int cmpdata = 0;
            cmpdata = Data.CompareTo(other.Data);
            return cmpdata;
        }
    }
}
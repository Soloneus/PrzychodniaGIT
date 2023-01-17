using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PrzychodniaGIT;

namespace PrzychodniaGIT
{
    [DataContract]
    [KnownType(typeof(Pacjent))]
    [KnownType(typeof(Lekarz))]
    public class Placówka
    {
        List<Lekarz> lekarze;
        List<Pacjent> pacjenci;
        List<Wizyta> wizyty;
        TimeSpan godzinaOtwarcia;
        TimeSpan godzinaZamkniecia;
        Dictionary<string, string> konta;

        [DataMember]
        public TimeSpan GodzinaOtwarcia { get => godzinaOtwarcia; set => godzinaOtwarcia = value; }
        [DataMember]
        public TimeSpan GodzinaZamkniecia { get => godzinaZamkniecia; set => godzinaZamkniecia = value; }
        [DataMember]
        public List<Lekarz> Lekarze { get => lekarze; set => lekarze = value; }
        [DataMember]
        public List<Wizyta> Wizyty { get => wizyty; set => wizyty = value; }
        [DataMember]
        public List<Pacjent> Pacjenci { get => pacjenci; set => pacjenci = value; }

        [DataMember]
        public Dictionary<string, string> Konta { get => konta; set => konta = value; }


        public Placówka()
        {
            Lekarze = new();
            Pacjenci = new();
            Wizyty = new();
            godzinaOtwarcia = new();
            godzinaZamkniecia = new();
            Konta = new();
        }

        public Placówka(TimeSpan godzinaOtwarcia, TimeSpan godzinaZamkniecia) : this()
        {
            GodzinaOtwarcia = godzinaOtwarcia;
            GodzinaZamkniecia = godzinaZamkniecia;
        }
        public Placówka(List<Lekarz> lekarze, List<Pacjent> pacjenci, List<Wizyta> wizyty, TimeSpan godzinaOtwarcia, TimeSpan godzinaZamkniecia) : this(godzinaOtwarcia, godzinaZamkniecia)
        {
            Lekarze = lekarze;
            Pacjenci = pacjenci;
            Wizyty = wizyty;
        }

        public void DodajWizyte(Wizyta wizyta)
        {
            if (wizyta == null) { return; }
            if (wizyta.Lekarz.SprawdzCzyMoznaUmowic(wizyta.Data.ToShortDateString(), wizyta.Godzina))
            {
                wizyta.Lekarz.Zaplanowane_Wizyty.Add(new Tuple<DateTime, TimeSpan>(wizyta.Data, wizyta.Godzina), true);
                Wizyty.Add(wizyta);
            }
        }
        public void ZakonczWizyte(Diagnoza diagnoza) //jak w WPF bedzie to idk czy to trzeba bedzie zmienic na inne argumenty
        {
            Wizyta w1 = diagnoza.Wizyta;
            w1.Pacjent.DodajDiagnoze(diagnoza);
            Wizyty.Remove(w1);
        }

        public void AnulujWizyteJakoLekarz(string pesel, DateTime data, TimeSpan godzina)
        {
            Wizyta wizyta = Wizyty.FirstOrDefault(w => w.Lekarz.Pesel == pesel && w.Data == data && w.Godzina == godzina);
            if (wizyta != null)
            {
                Wizyty.Remove(wizyta);
                wizyta.Lekarz.Zaplanowane_Wizyty.Remove(new Tuple<DateTime, TimeSpan>(data, godzina));
            }
            return;
        }

        public void AnulujWizytePacjent(string pesel, DateTime data, TimeSpan godzina)
        {
            Wizyta wizyta = Wizyty.FirstOrDefault(w => w.Pacjent.Pesel == pesel && w.Data == data && w.Godzina == godzina);
            if (wizyta != null)
            {
                Wizyty.Remove(wizyta);
                wizyta.Lekarz.Zaplanowane_Wizyty.Remove(new Tuple<DateTime, TimeSpan>(data, godzina));
            }
            return;
        }
        public void DodajPacjenta(Pacjent p1)
        {
            Pacjenci.Add(p1);
        }

        public void DodajKonto(string pesel, string haslo)
        {
            if (pesel == null || haslo == null) { return; }
            Konta.Add(pesel, haslo);
        }

        public void DodajLekarza(Lekarz l1)
        {
            Lekarze.Add(l1);
        }

        public void UsunLekarza(string pesel)
        {
            Lekarz l1 = Lekarze.Find(p => p.Pesel == pesel);
            if (Lekarze.Find(p => p.Pesel == pesel) == null) { return; }
            Wizyty.ToList().RemoveAll(p => p.Lekarz.Pesel == pesel);
            Lekarze.Remove(l1);
        }
        public void UsuńPacjenta(string pesel)
        {
            List<Wizyta> wizytyanulowane = new List<Wizyta>();
            Pacjent p1 = Pacjenci.Find(p => p.Pesel == pesel);
            if (Pacjenci.Find(p => p.Pesel == pesel) == null) { return; }
            wizytyanulowane = Wizyty.FindAll(p => p.Pacjent.Pesel == pesel);

            foreach (Wizyta w in wizytyanulowane)
            {
                w.Lekarz.Zaplanowane_Wizyty.Remove(new Tuple<DateTime, TimeSpan>(w.Data, w.Godzina));
            }

            Wizyty.RemoveAll(p => p.Pacjent.Pesel == pesel);
            Konta.Remove(pesel);
            Pacjenci.Remove(p1);
        }
        public string HistoriaPacjenta(string pesel)
        {
            StringBuilder sb = new();
            Pacjent pacjent = Pacjenci.Find(p => p.Pesel == pesel);
            if (pacjent == null) { return "Brak pacjenta w bazie danych."; }
            pacjent.HistoriaWizyt.ForEach(w => sb.AppendLine(w.ToString()));
            if (sb.ToString() == null) { return "Brak historii"; }
            return sb.ToString();
        }
        public List<Wizyta> LekarzWDanymDniu(string pesel, DateTime data)
        {

            List<Wizyta> wizytyulekarza = Wizyty.FindAll(w => w.Lekarz.Pesel == pesel && w.Data.Date == data);
            return wizytyulekarza;
        }
        public List<Wizyta> WszystkieWizyty()
        {
            return Wizyty;
        }

        public List<Wizyta> WizytyPacjenta(string pesel)
        {
            List<Wizyta> wizyty = new();
            wizyty = Wizyty.FindAll(p => p.Pacjent.Pesel == pesel);
            return wizyty;
        }

        public void ZapiszDC(string fname)
        {
            using FileStream fs = new(fname, FileMode.Create);
            DataContractSerializer dc = new(typeof(Placówka));
            dc.WriteObject(fs, this);
        }
        public static Placówka? OdczytDC(string fname)
        {
            if (!File.Exists(fname)) { return null; }
            using FileStream fs = new(fname, FileMode.Open);
            DataContractSerializer dc = new(typeof(Placówka));
            return dc.ReadObject(fs) as Placówka;
        }

        public void SortujWizyta()
        {
            Wizyty.Sort();
        }

        public List<Lekarz> WyszukajSpecjalizacja(string specjalizacja)
        {
            return Lekarze.FindAll(p => p.Specjalizacja.Equals(specjalizacja));
        }

        public bool HasloRejestracjaPacjent(string pesel, string haslo)
        {
            if (Konta.Keys.First().Equals(pesel) != null)
            {
                if (Pacjenci.FindAll(p => p.Pesel == pesel) == null)
                {
                    return true;
                }
                return false;
            }
            Konta.Add(pesel, haslo);
            return true;
        }
    }
}
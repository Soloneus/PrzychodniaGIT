using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrzychodniaGIT;

namespace PrzychodniaGIT
{
    public class Placówka
    {
        List<Lekarz> lekarze;
        List<Pacjent> pacjenci;
        List<Wizyta> wizyty;
        TimeSpan godzinaOtwarcia;
        TimeSpan godzinaZamkniecia;

        public TimeSpan GodzinaOtwarcia { get => godzinaOtwarcia; set => godzinaOtwarcia = value; }
        public TimeSpan GodzinaZamkniecia { get => godzinaZamkniecia; set => godzinaZamkniecia = value; }
        public List<Lekarz> Lekarze { get => lekarze; set => lekarze = value; }
        public List<Wizyta> Wizyty { get => wizyty; set => wizyty = value; }
        public List<Pacjent> Pacjenci { get => pacjenci; set => pacjenci = value; }
        public Placówka()
        {
            Lekarze = new();
            Pacjenci = new();
            Wizyty = new();
            godzinaOtwarcia = new();
            godzinaZamkniecia = new();
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
            wizyty.Add(wizyta);
            wizyty.ToList();
        }
        public void ZakonczWizyte(Diagnoza diagnoza) //jak w WPF bedzie to idk czy to trzeba bedzie zmienic na inne argumenty
        {
            Wizyta w1 = diagnoza.Wizyta;
            w1.Pacjent.DodajDiagnoze(diagnoza);
            wizyty.Remove(w1);
        }

        public void AnulujWizyteJakoLekarz(string pesel, DateTime dataod)
        {
            Wizyta wizyta = Wizyty.FirstOrDefault(w => w.Lekarz.Pesel == pesel && w.DataOd == dataod);
            if (wizyta != null)
            {
                Wizyty.Remove(wizyta);
            }
            return;
        }

        public void AnulujWizytePacjent(string pesel, DateTime dataod)
        {
            Wizyta wizyta = Wizyty.FirstOrDefault(w => w.Pacjent.Pesel == pesel && w.DataOd == dataod);
            if (wizyta != null)
            {
                Wizyty.Remove(wizyta);
            }
            return;
        }
        public void DodajPacjenta(Pacjent p1)
        {
            Pacjenci.Add(p1);
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
            Pacjent p1 = Pacjenci.Find(p => p.Pesel == pesel);
            if (Pacjenci.Find(p => p.Pesel == pesel) == null) { return; }
            Wizyty.ToList().RemoveAll(p => p.Pacjent.Pesel == pesel);
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

            List<Wizyta> wizytyulekarza = wizyty.ToList().FindAll(w => w.Lekarz.Pesel == pesel && w.DataOd.Date == data);
            return wizytyulekarza;
        }
        public List<Wizyta> WszystkieWizyty()
        {
            return Wizyty;
        }
    }
}
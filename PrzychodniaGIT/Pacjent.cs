﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PrzychodniaGIT;

//k
namespace PrzychodniaGIT
{
    [DataContract]
    public class Pacjent : Osoba
    {
        List<Diagnoza> historiaWizyt;

        [DataMember]
        public List<Diagnoza> HistoriaWizyt { get => historiaWizyt; set => historiaWizyt = value; }
        public Pacjent() : base() { HistoriaWizyt = new(); }
        public Pacjent(string imie, string nazwisko, EnumPlec plec) : base(imie, nazwisko, plec) { HistoriaWizyt = new(); }
        public Pacjent(string imie, string nazwisko, string dataUrodzenia,
            string pesel, EnumPlec plec) : base(imie, nazwisko, dataUrodzenia, pesel, plec) { HistoriaWizyt = new(); }

        public void DodajDiagnoze(Diagnoza d)
        {
            if (HistoriaWizyt == null) { return; }
            HistoriaWizyt.Add(d);
        }
        public void UsunDiagnoze(Diagnoza d)
        {
            HistoriaWizyt.Remove(d);
        }

    }
}
using PrzychodniaGIT;


Lekarz przykladowyLekarz = new Lekarz("Jan", "Kowalski", "01.01.1980", "12345678901", EnumPlec.M, "Dzieciecy",
            new Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>>
            {
                { DayOfWeek.Monday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Tuesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Wednesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Thursday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Friday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) }
            });

Lekarz przykladowyLekarz1 = new Lekarz("Julia", "Błoń", "01.01.1990", "90312345678", EnumPlec.K, "Dzieciecy",
            new Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>>
            {
                { DayOfWeek.Monday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0)) },
                { DayOfWeek.Tuesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Wednesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(13, 0, 0)) },
                { DayOfWeek.Thursday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Friday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) }
            });
Lekarz przykladowyLekarz2 = new Lekarz("Julian", "Kieł", "01.01.1970", "80312345678", EnumPlec.M, "Dzieciecy",
            new Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>>
            {
                { DayOfWeek.Monday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0)) },
                { DayOfWeek.Tuesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Wednesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Thursday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Friday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) }
            });
Lekarz przykladowyLekarz3 = new Lekarz("Patryk", "Opl", "01.01.1990", "90312345677", EnumPlec.M, "Dzieciecy",
            new Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>>
            {
                { DayOfWeek.Monday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0)) },
                { DayOfWeek.Tuesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Wednesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Thursday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Friday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) }
            });
Lekarz przykladowyLekarz4 = new Lekarz("Mariusz", "Pudzianowski", "01.01.1990", "903812345677", EnumPlec.M, "Dzieciecy",
            new Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>>
            {
                { DayOfWeek.Monday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0)) },
                { DayOfWeek.Tuesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Wednesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Thursday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Saturday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) }
            });


Pacjent p1 = new("Adam", "Małysz", "30-06-1980", "02263001875", EnumPlec.M);
Pacjent p2 = new("Jan", "Nowak", "30-01-2006", "02463001875", EnumPlec.M);
Pacjent p3 = new("Julia", "Jak", "30-01-1999", "02453001875", EnumPlec.K);

Placówka przychodnia = new();
przychodnia.DodajPacjenta(p1);
przychodnia.DodajPacjenta(p2);
przychodnia.DodajPacjenta(p3);


przychodnia.DodajLekarza(przykladowyLekarz);
przychodnia.DodajLekarza(przykladowyLekarz1);
przychodnia.DodajLekarza(przykladowyLekarz2);
przychodnia.DodajLekarza(przykladowyLekarz3);
przychodnia.DodajLekarza(przykladowyLekarz4);

przychodnia.DodajKonto(p1.Pesel, "123456");
przychodnia.DodajKonto(p2.Pesel, "hasło");
przychodnia.DodajKonto(p3.Pesel, "password");
przychodnia.DodajKonto(przykladowyLekarz.Pesel, "123123");
przychodnia.DodajKonto(przykladowyLekarz1.Pesel, "lekarz");
przychodnia.DodajKonto(przykladowyLekarz2.Pesel, "0911d");
przychodnia.DodajKonto(przykladowyLekarz3.Pesel, "0911e");
przychodnia.DodajKonto(przykladowyLekarz4.Pesel, "0911f");

foreach (var d in przychodnia.Konta)
{
    Console.WriteLine(d);
}

foreach (Pacjent p in przychodnia.Pacjenci)
{
    Console.WriteLine(p);
}

foreach (Lekarz l in przychodnia.Lekarze)
{
    Console.WriteLine(l);
}

Wizyta w1 = new("19-05-2023", przykladowyLekarz, p1, new TimeSpan(9, 0, 0));
Wizyta w2 = new("20-02-2023", przykladowyLekarz, p2, new TimeSpan(8, 0, 0));
Wizyta w3 = new("23-02-2023", przykladowyLekarz, p3, new TimeSpan(8, 0, 0));
Wizyta w4 = new("23-02-2023", przykladowyLekarz, p1, new TimeSpan(9, 0, 0));
Wizyta w5 = new("23-01-2023", przykladowyLekarz1, p2, new TimeSpan(16, 0, 0));
Wizyta w6 = new("20-02-2023", przykladowyLekarz, p2, new TimeSpan(9, 0, 0));
Wizyta w7 = new("21-02-2023", przykladowyLekarz, p1, new TimeSpan(7, 0, 0));
Wizyta w8 = new("19-05-2023", przykladowyLekarz, p2, new TimeSpan(9, 0, 0));

//przychodnia.DodajWizyte(w5);

//foreach (Wizyta a in przychodnia.WszystkieWizytyDanegoLekarza("90312345678"))
//{
//    Console.WriteLine(a);
//}

//Console.WriteLine("---------");

//przychodnia.DodajWizyte(w1);
//przychodnia.DodajWizyte(w2);
//przychodnia.DodajWizyte(w3);
//przychodnia.DodajWizyte(w4);
//przychodnia.DodajWizyte(w6);
//przychodnia.DodajWizyte(w7);



//foreach (Wizyta w in przychodnia.Wizyty)
//{
//    Console.WriteLine(w);
//}
//Console.WriteLine(przychodnia.Wizyty.Count.ToString());

//Console.WriteLine("-----------------------------------");

//Console.WriteLine(przychodnia.Wizyty.Count.ToString());
//przychodnia.DodajWizyte(w8);

//wszystkie wizyty check
//wyszukaj specjalizacja check

//foreach(Wizyta w in przychodnia.Wizyty)
//{

//    Console.WriteLine(w);
//}

//przychodnia.DodajWizyte(w1);


//foreach(Wizyta a in przychodnia.WszystkieWizytyUDanegoLekarza("12345678901"))
//{
//    Console.WriteLine(a.ToString());
//}

//Console.WriteLine(przychodnia.WszystkieWizyty());

//foreach (Wizyta p in przychodnia.WizytyPacjenta("02263001875"))
//{
//    Console.WriteLine(p);
//}
//Console.WriteLine(przychodnia.WizytyPacjenta("02263001875"));

//Console.WriteLine(przychodnia.LekarzWDanymDniu("12345678901", new DateTime(2022, 2, 21)));

foreach (Wizyta a in przychodnia.WszystkieWizytyDanegoLekarza("12345678901"))
{
    Console.WriteLine(a.ToString());
}

Console.WriteLine("=========");

Console.WriteLine(przychodnia.HistoriaPacjenta("02463001875"));


przychodnia.ZakonczWizyte(new(w2, "Zapalenie płuc", "Paracetamol"));
przychodnia.ZakonczWizyte(new(w6, "Nic", "Nic"));

Console.WriteLine(przychodnia.HistoriaPacjenta("02463001875"));

Console.WriteLine("=======");

foreach (Wizyta a in przychodnia.WszystkieWizytyDanegoLekarza("12345678901"))
{
    Console.WriteLine(a.ToString());
}
Console.WriteLine("=========");

przychodnia.AnulujWizyteJakoLekarz(p3.Pesel, w4.Data, w4.Godzina);

Console.WriteLine(przychodnia.HistoriaPacjenta("02463001875"));
Console.WriteLine("=========");
List<Diagnoza> ab = (przychodnia.Pacjenci.Find(p => p.Pesel == "02463001875").HistoriaWizyt);
foreach (Diagnoza d in ab)
{
    Console.WriteLine(d.ToString());
}

Console.WriteLine(przychodnia.WszystkieWizyty());

Console.WriteLine(przychodnia.Lekarze.Find(p => p.Specjalizacja == "Dzieciecy"));


string fname = "przychodnia.xml";
przychodnia.ZapiszDC(fname);

Placówka zespolodczyt = Placówka.OdczytDC(fname);
Console.WriteLine("Po odczycie:");

Console.WriteLine(zespolodczyt.HistoriaPacjenta("02463001875"));

foreach (Lekarz l in przychodnia.WyszukajSpecjalizacja("Dzieciecy"))
{
    Console.WriteLine(l);
}

foreach (Pacjent pt in przychodnia.Pacjenci)
{
    Console.WriteLine(pt);
}

foreach (Pacjent p in zespolodczyt.Pacjenci)
{
    Console.WriteLine(p);
}

Console.WriteLine(przykladowyLekarz.SprawdzCzyMoznaUmowic("22-11-2022", new TimeSpan(8, 0, 0)));

Console.WriteLine(zespolodczyt.Konta.Count.ToString());


Console.WriteLine(przychodnia.HasloRejestracjaPacjent("12345678901", "123123"));





//zespolodczyt.UsuńPacjenta("02263001875");
//przychodnia.UsuńPacjenta("02263001875");
//Console.WriteLine(przychodnia.HistoriaPacjenta("02263001875"));


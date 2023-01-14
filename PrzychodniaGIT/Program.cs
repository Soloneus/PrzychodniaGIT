// See https://aka.ms/new-console-template for more information
using PrzychodniaGIT;
using static System.Net.Mime.MediaTypeNames;

Lekarz przykladowyLekarz = new Lekarz("Jan", "Kowalski", "01.01.1980", "12345678901", EnumPlec.M, EnumSpecjalizacja.Dzieciecy, "32rfew",
            new Dictionary<DayOfWeek, Tuple<TimeSpan, TimeSpan>>
            {
                { DayOfWeek.Monday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Tuesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Wednesday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Thursday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) },
                { DayOfWeek.Friday, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0)) }
            });
Console.WriteLine(przykladowyLekarz);

Pacjent p1 = new("Mateusz", "Strojek", "30-06-2002", "02263001875", EnumPlec.M, "22");
Pacjent p2 = new("Jan", "Nowak", "30-01-2006", "02463001875", EnumPlec.M, "213gfds");
Pacjent p3 = new("Julia", "Jak", "30-01-1999", "02463401875", EnumPlec.K, "241gdsf");

Placówka przychodnia = new();
przychodnia.DodajPacjenta(p1);
przychodnia.DodajPacjenta(p2);
przychodnia.DodajPacjenta(p3);

Wizyta w1 = new("19-02-2022", przykladowyLekarz, p1);
Wizyta w2 = new("20-02-2022", przykladowyLekarz, p2);
Wizyta w3 = new("21-02-2022", przykladowyLekarz, p3);
Wizyta w4 = new("22-02-2022", przykladowyLekarz, p1);
Wizyta w5 = new("23-02-2022", przykladowyLekarz, p2);
Wizyta w6 = new("25-02-2022", przykladowyLekarz, p2);
Wizyta w7 = new("21-02-2022", przykladowyLekarz, p1);

przychodnia.DodajWizyte(w1);
przychodnia.DodajWizyte(w2);
przychodnia.DodajWizyte(w3);
przychodnia.DodajWizyte(w4);
przychodnia.DodajWizyte(w5);
przychodnia.DodajWizyte(w6);
przychodnia.DodajWizyte(w7);

przychodnia.AnulujWizyteJakoLekarz("12345678901", new DateTime(2022, 2, 19));
Console.WriteLine(przychodnia.WszystkieWizyty());

Console.WriteLine(przychodnia.LekarzWDanymDniu("12345678901", new DateTime(2022, 2, 21)));


przychodnia.ZakonczWizyte(new(w2, "Zapalenie płuc", "Paracetamol"));
przychodnia.ZakonczWizyte(new(w6, "Nic", "Nic"));

//Console.WriteLine(przychodnia.HistoriaPacjenta("02463001875"));
Console.WriteLine(przychodnia.WszystkieWizyty());

przychodnia.ZapiszXml("plik.xml");

System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(przychodnia.GetType());
x.Serialize(Console.Out, przychodnia);
//przychodnia.UsuńPacjenta("02263001875");
//Console.WriteLine(przychodnia.HistoriaPacjenta("02263001875"));


//w1.SprawdzCzyWolny("27-12-2022", new TimeSpan(13, 0, 0), new TimeSpan(19, 0, 0));
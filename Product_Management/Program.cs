using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Product_Management
{
    class Program
    {
        public static List<Zamowienie> zamowienia;
        public static bool repeat = true;
        public static string pathP = @"C:\Users\Daniel\source\repos\danyPL\Product_Management\produkty.json";
        public static string pathZ = @"C:\Users\Daniel\source\repos\danyPL\Product_Management\zamowienia.json";

        public static void Main(string[] args)
        {
            try
            {
                while (repeat)
                {
                    if (!File.Exists(pathP))
                    {
                        File.Create(pathP).Close();
                    }
                    if (!File.Exists(pathZ))
                    {
                        File.Create(pathZ).Close();
                    }

                    string json = File.ReadAllText(pathZ);
                    zamowienia = JsonSerializer.Deserialize<List<Zamowienie>>(json);

                    Console.Clear();
                    Console.WriteLine("Witaj w Menadżerze Zamówień!\n Wybierz opcje zamówienia: \n 1. Stwórz zamówienie \n 2. Wyświetl Zamówienia \n 3. Wyjdz");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    

                    

                        switch (choice)
                    {
                        case 1:
                            AddOrder();
                            break;
                        case 2:
                            ShowOrders();
                            break;
                        case 3:
                            Console.WriteLine("Wychodzenie...");
                            repeat = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void AddOrder()
        {
            bool rep = true;
            Console.WriteLine("Aby stworzyć zamówienie podaj odpowiednie dane!");
            Console.WriteLine("Podaj Imie:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj Adres:");
            string adres = Console.ReadLine();
            Console.WriteLine("Podaj Sposób dostawy: \n1. kurier[cena 20zł] \n2. odbior osobisty[cena 0zł]");
            string sposob_dostawy = Console.ReadLine() == "1" ? "kurier" : "odbior osobisty";
            Console.WriteLine("Podaj Sposób płatności: \n1. karta[cena 2zł] \n2. gotówką[cena 0zł])");
            string sposob_platnosci = Console.ReadLine() == "1" ? "karta" : "gotowka";
            
            List<Product> produktyG;
            string json = File.ReadAllText(pathP);
            produktyG = JsonSerializer.Deserialize<List<Product>>(json);

            Zamowienie nowe_zamowienie = new Zamowienie(
               zamowienia.Count + 1,
               imie,
               nazwisko,
               adres,
               sposob_dostawy,
               sposob_platnosci,
               0,
               null
            );

            while (rep)
            {
                Console.Clear();
                Console.WriteLine("Wybierz akcje zamowienia: ");
                Console.WriteLine(" 1. Dodaj produkt po nazwie\n 2. Wyświetl wszystkie produkty \n 3. Pokaz Szczegoly zamowienia\n 4. Złóż zamówienie");
                string Temp_name_produkt;
                int choice = Convert.ToInt32( Console.ReadLine() );
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwę produktu");
                        Temp_name_produkt = Console.ReadLine();
                    foreach (Product produkt in produktyG)
                {
                    if (Temp_name_produkt == produkt.Nazwa)
                    {
                        nowe_zamowienie.Dodaj_Produkt(produkt);
                        Temp_name_produkt = "";
                                Console.ReadKey();

                            }
                        }
                        break;
                        case 2:
                        Console.WriteLine("----------------------------------------");

                        foreach (Product p in produktyG)
                        {
                            Console.WriteLine($"{p.Nazwa} - {p.Cena}zł");
                        }
                        Console.WriteLine("----------------------------------------");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Zamówienie z dnia {DateTime.Now}");
                        Console.WriteLine($"Imie osoby zamawiajacej: {nowe_zamowienie.Imie}");
                        Console.WriteLine($"Nazwisko osoby zamawiajacej: {nowe_zamowienie.Nazwisko}");
                        Console.WriteLine($"Adres osoby zamawiajacej: {nowe_zamowienie.Adres}");
                        Console.WriteLine($"Sposob Platnosci osoby zamawiajacej: {nowe_zamowienie.Sposob_platnosci}");
                        Console.WriteLine($"Sposob Dostawy osoby zamawiajacej: {nowe_zamowienie.Sposob_dostawy}");
                        Console.WriteLine($"Wybrane produkty:");
                        foreach(Product p in nowe_zamowienie.Products)
                        {
                            Console.WriteLine($"{p.Nazwa} - {p.Cena}zł");
                        }

                        Console.WriteLine("----------------------------------------");
                        Console.ReadKey();
                        break;
                    case 4:

        Console.WriteLine("Obliczanie kosztu wysyłki....");
            nowe_zamowienie.Oblicz();
            double cena = nowe_zamowienie.Kwota_cal;
            Console.WriteLine($"Koszt Zamowienia jest równy: {cena}zł");
            zamowienia.Add(nowe_zamowienie);
            string jsonD = JsonSerializer.Serialize<List<Zamowienie>>(zamowienia);

            File.WriteAllText(pathZ, jsonD);
            Console.WriteLine("Zamówienie dodane!");
                        rep = false;
            Console.ReadKey();
                        break;
                }

                
            }

           
        }

        static void ShowOrders()
        {
            Console.WriteLine("Lista zamówień:");
            foreach (var zamowienie in zamowienia)
            {
                Console.WriteLine($"Id: {zamowienie.Id}, Imie: {zamowienie.Imie}, Nazwisko: {zamowienie.Nazwisko}, Adres: {zamowienie.Adres}, Sposób dostawy: {zamowienie.Sposob_dostawy}, Sposób płatności: {zamowienie.Sposob_platnosci}, Kwota całkowita: {zamowienie.Kwota_cal}zł");
            }
            Console.WriteLine("Koniec listy.");
            Console.ReadKey();
        }
    }
}
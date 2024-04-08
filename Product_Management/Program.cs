
using System.IO;
using System.Text.Json;

namespace Product_Management
{
class Program
    {
        public static List<Zamowienie> zamowenia; 
        public static bool repeat = true;
        public static string pathP = @"C:\Users\danypolska\source\repos\Product_Management\produkty.json";
        public static string pathZ = @"C:\Users\danypolska\source\repos\Product_Management\zamowienia.json";

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
                    string json = File.ReadAllText(pathZ);
                    zamowenia = JsonSerializer.Deserialize<List<Zamowienie>>(json);
                    Console.Clear();
                    Console.WriteLine(json);
                Console.WriteLine("Witaj w Menadżerze Zamówień!\n Wybierz opcje zamówienia: \n 1. Stwórz zamówienie \n 2.Wyświetl Zamówienia \n 3. Wyjdz");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                            AddOrder();
                        break;
                    case 2:

                        break;
                    case 3:
                        Console.WriteLine("Wychodzenie...");
                        repeat = false;
                        break;
                }
            }
            }catch (Exception ex)
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
            Console.WriteLine("Podaj Sposób dostawy: \n(kurier[cena 20zł],odbior osobisty[cena 0zł])");
            string sposob_dostawy = Console.ReadLine();
            Console.WriteLine("Podaj Sposób płatności: \n(karta[cena 2zł], gotówką[cena 0zł])");
            string sposob_platnosci = Console.ReadLine();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Podaj produkty po nazwach: \nPodawaj produkty po enetrze, gdy będziesz chciał zakończysz wpisz 'koniec'");
            List<Product> produktyG;
            string json = File.ReadAllText(pathP);
            produktyG = JsonSerializer.Deserialize<List<Product>>(json);
            Zamowienie nowe_zamowienie = new Zamowienie(
               zamowenia.Count + 1,
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
                int choice = Console.ReadLine() != "koniec" ? 1 : 2;
                if (!File.Exists(pathP))
                {
                    File.Create(pathP).Close();
                }
                
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwe:");
                        string nazwa = Console.ReadLine();
                        foreach(Product produkt in produktyG)
                        {
                            if(nazwa == produkt.Nazwa)
                            {
                              nowe_zamowienie.Dodaj_Produkt(produkt);
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        repeat = false;
                        Console.ReadKey();
                        break;
                }
            }
           
            
            Console.WriteLine("Obliczanie kosztu wysyłki....");
            nowe_zamowienie.Oblicz();
            double cena = nowe_zamowienie.Kwota_cal;
            Console.WriteLine($"Koszt Zamowienia jest równy: {cena}zł");
            zamowenia.Add(nowe_zamowienie);
            string jsonD = JsonSerializer.Serialize<List<Zamowienie>>(zamowenia);

            File.WriteAllText(pathZ, jsonD);
            Console.WriteLine("Zamówienie dodane!");
            Console.ReadKey();
        }
        static void ShowOrders()
        {

        }
    }
}
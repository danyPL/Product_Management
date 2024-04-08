using System;
using System.Collections.Generic;

namespace Product_Management
{
    public class Zamowienie
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Sposob_dostawy { get; set; }
        public string Sposob_platnosci { get; set; }
        public double Kwota_cal { get; set; }
        public List<Product> Products { get; set; }

        public Zamowienie() { }

        public Zamowienie(int id, string imie, string nazwisko, string adres, string sposob_dostawy, string sposob_platnosci, double kwota_cal, List<Product> products)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Adres = adres;
            Sposob_dostawy = sposob_dostawy;
            Sposob_platnosci = sposob_platnosci;
            Kwota_cal = kwota_cal;
            Products = products ?? new List<Product>();
        }

        public void Dodaj_Produkt(Product product)
        {
            Products.Add(product);
        }

        public void Oblicz()
        {
            double cena = 0;
            if (Sposob_dostawy == "kurier")
            {
                cena += 20;
            }
            if (Sposob_platnosci == "karta")
            {
                cena += 2;
            }
            foreach (Product p in Products)
            {
                cena += p.Cena;
            }
            Kwota_cal = Math.Floor(cena);
        }
    }
}
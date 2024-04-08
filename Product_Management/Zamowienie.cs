using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Product>? products { get; set; }

        public Zamowienie(int Id,string imie,string nazwisko,string Adres,string sposob_dostawy,string sposob_plantosci,double kwota_cal, List<Product>? Products) { 
            this.Id = Id;
            this.Imie = imie;
            this.Nazwisko= nazwisko;
            this.Adres = Adres;
            this.Sposob_dostawy= sposob_dostawy;
            this.Sposob_platnosci = sposob_plantosci;
            this.Kwota_cal = Kwota_cal;
            this.products = Products;
        }
        public void Dodaj_Produkt(Product product)
        {
            products.Add(product);
        }
        public void Oblicz()
        {
            double cena = 0;
            if (Sposob_dostawy == "kurier")
            {
                cena += 10;
            }
        if(Sposob_platnosci == "karta")
            {

                cena += 2;
            }
            foreach(Product p in products)
            {
                cena += p.Cena;
            }
            Kwota_cal = cena;
        }
    }
}

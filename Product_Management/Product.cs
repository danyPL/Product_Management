using System;

namespace Product_Management
{
    public class Product
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Producent { get; set; }
        public float Cena { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; set; }
        public DateTime Data { get; set; }

        public Product() { }

        public Product(string nazwa, string producent, float cena, string kategoria, int ilosc, DateTime data)
        {
            Nazwa = nazwa;
            Producent = producent;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
            Data = data;
        }
    }
}
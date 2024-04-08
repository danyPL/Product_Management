using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management
{
    public class Product
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string  Producent { get; set; }
        public float Cena { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; set; }
        public DateTime Data { get; set; }
        public Product(string nazwa,string producent,float cena, string kategoria,int ilosc,DateTime data) {
            this.Nazwa = nazwa;
            this.Producent = producent;
            this.Cena = cena;
            this.Kategoria = kategoria;
            this.Ilosc = ilosc;
            this.Data = data;
        }
    }
}

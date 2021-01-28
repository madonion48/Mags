using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mags.Models
{
    public class Stoc
    {
        public int ID { get; set; }
        [Display(Name = "Produs")]
        public Produs EAN { get; set; }
        [Display(Name = "Nume produs")]
        public string Produs { get; set; }
        public string Furnizor { get; set; }
        [Display(Name = "Cod palet")]
        public string SSCC { get; set; }
        public decimal Cantitate { get; set; }
        [Display(Name = "Adresă")]
        public string Adresa { get; set; }
        [Display(Name = "Recepție")]
        public Receptie Receptie { get; set; }
        [Display(Name = "Comandă")]
        public Comanda Comanda { get; set; }
        public string Client { get; set; }
    }
}

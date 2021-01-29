using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mags.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        public string Client { get; set; }
        public Produs EAN { get; set; }
        [Display(Name = "Cantitate comandată")]
        public decimal Cantitate { get; set; }
        [Display(Name = "Cantitate livrată")]
        public decimal Livrata { get; set; }
    }
}

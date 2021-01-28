using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mags.Models
{
    public class Receptie
    {
        public int ID { get; set; }
        public string Furnizor { get; set; }
        public Produs EAN { get; set; }
        [Display(Name = "EAN")]
        public string EAN_Produs { get; set; }
        [Display(Name = "Cod palet")]
        public string SSCC { get; set; }
        public decimal Cantitate { get; set; }
    }
}

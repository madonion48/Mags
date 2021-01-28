using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mags.Models
{
    public class Produs
    {
        public int ID { get; set; }
        public string EAN { get; set; }
        [Display(Name = "Nume Produs")]
        public string Nume { get; set; }
        public decimal Lungime { get; set; }
        [Display(Name = "Lățime")]
        public decimal Latime { get; set; }
        [Display(Name = "Înălțime")]
        public decimal Inaltime { get; set; }
    }
}

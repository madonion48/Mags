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
        public decimal Cantitate { get; set; }
    }
}

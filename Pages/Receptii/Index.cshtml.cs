using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mags.Data;
using Mags.Models;

namespace Mags.Pages.Receptii
{
    public class IndexModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public IndexModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public IList<Receptie> Receptie { get;set; }

        public IList<Produs> Produs { get; set; }

        public List<Produs> Products { get; set; } = new List<Produs>();

        public async Task OnGetAsync()
        {
            Receptie = await _context.Receptie.ToListAsync();
            Products = await _context.Produs.ToListAsync();

        }
 
    }
}

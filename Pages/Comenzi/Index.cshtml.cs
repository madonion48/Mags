using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mags.Data;
using Mags.Models;

namespace Mags.Pages.Comenzi
{
    public class IndexModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public IndexModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public IList<Comanda> Comanda { get;set; }

        public async Task OnGetAsync()
        {
            Comanda = await _context.Comanda.ToListAsync();
        }
    }
}

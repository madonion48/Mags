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
    public class DetailsModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public DetailsModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public Comanda Comanda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comanda = await _context.Comanda.FirstOrDefaultAsync(m => m.ID == id);

            if (Comanda == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

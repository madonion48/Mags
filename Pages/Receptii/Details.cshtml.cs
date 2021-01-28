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
    public class DetailsModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public DetailsModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public Receptie Receptie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Receptie = await _context.Receptie.FirstOrDefaultAsync(m => m.ID == id);

            if (Receptie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

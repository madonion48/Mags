using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mags.Data;
using Mags.Models;

namespace Mags.Pages.Stocuri
{
    public class DeleteModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public DeleteModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stoc Stoc { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stoc = await _context.Stoc.FirstOrDefaultAsync(m => m.ID == id);

            if (Stoc == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stoc = await _context.Stoc.FindAsync(id);

            if (Stoc != null)
            {
                _context.Stoc.Remove(Stoc);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

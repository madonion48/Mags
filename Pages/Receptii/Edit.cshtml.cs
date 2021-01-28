using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mags.Data;
using Mags.Models;

namespace Mags.Pages.Receptii
{
    public class EditModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public EditModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Receptie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceptieExists(Receptie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReceptieExists(int id)
        {
            return _context.Receptie.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mags.Data;
using Mags.Models;

namespace Mags.Pages.Stocuri
{
    public class CreateModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public CreateModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stoc Stoc { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stoc.Add(Stoc);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

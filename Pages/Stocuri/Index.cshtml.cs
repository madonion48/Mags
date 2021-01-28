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
    public class IndexModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public IndexModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public IList<Stoc> Stoc { get;set; }

        public async Task OnGetAsync()
        {
            Stoc = await _context.Stoc.ToListAsync();
        }

    }
}

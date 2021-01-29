using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mags.Data;
using Mags.Models;

namespace Mags.Pages.Receptii
{
    public class CreateModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;

        public List<Produs> ListaProduse { get; set; }

        public CreateModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // recuperare lista EANuri din bdd
            var data = (from listaproduse in _context.Produs select listaproduse).ToList();
            ListaProduse = data;

            // creez un view pentru a alimenta dropdownlist-ul EAN - afisam numele 
            var fromDatabaseEF = new SelectList(_context.Produs.ToList(), "ID", "Nume");
            ViewData["DBProdus"] = fromDatabaseEF;
            return Page();
        }

        [BindProperty]
        public Receptie Receptie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string EanID = Request.Form["LP"].ToString();
            var data = (from listaproduse in _context.Produs select listaproduse).ToList();
            ListaProduse = data;
            Stoc objStoc = new Stoc();

            foreach (Produs produs in ListaProduse)
            {
                if (EanID.Equals(produs.ID.ToString()))
                {
                    objStoc.Produs = produs.Nume;
                    Receptie.EAN = produs;
                    Receptie.EAN_Produs = produs.EAN;
                    break;
                }
            }        
            
            _context.Receptie.Add(Receptie);
            await _context.SaveChangesAsync();

            objStoc.EAN = Receptie.EAN;
            objStoc.Cantitate = Receptie.Cantitate;
            objStoc.Furnizor = Receptie.Furnizor;
            objStoc.SSCC = Receptie.SSCC;
            objStoc.Adresa = "În curs de stocare";
            objStoc.Receptie = Receptie;
            _context.Stoc.Add(objStoc);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("../Stocuri/Index");
        }
    }
}

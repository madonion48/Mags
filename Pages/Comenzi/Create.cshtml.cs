using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mags.Data;
using Mags.Models;
using System.Data.SqlClient;


namespace Mags.Pages.Comenzi
{
    public class CreateModel : PageModel
    {
        private readonly Mags.Data.MagsContext _context;
        public List<Stoc> ListaStoc { get; set; }
        public List<Produs> ListaProduse { get; set; }

        public CreateModel(Mags.Data.MagsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // creez un view pentru a alimenta dropdownlist-ul Nume Produs 
            var fromDatabaseEF = new SelectList((from listastoc in _context.Stoc where listastoc.Comanda == null select listastoc).ToList(), "ID", "Produs");
            ViewData["DBStoc"] = fromDatabaseEF;

            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // recuperare lista EANuri din bdd
            var datap = (from listaproduse in _context.Produs select listaproduse).ToList();
            ListaProduse = datap;

            var data = (from listastoc in _context.Stoc where listastoc.Comanda == null select listastoc).ToList();
            ListaStoc = data;
            string stocID = Request.Form["LP"].ToString();

            foreach (Stoc stoc in ListaStoc)
            {
                //identificam stocul ales
                if (stocID.Equals(stoc.ID.ToString()))
                {
                    //recuperam produsul stocului
                    foreach (Produs produs in ListaProduse)
                    {
                        if (produs.Nume.Equals(stoc.Produs))
                        {
                            Comanda.EAN = produs;
                            break;
                        }
                    }

                    // modificam stocul care ramane. Daca nu ramane nicio cantitate, stergem
                    // linia
                    decimal cantitate = stoc.Cantitate - Comanda.Cantitate;
                    decimal livrata = stoc.Cantitate;
                    if(cantitate <= 0)
                    {
                        // s-a consumat tot paletul
                        _context.Stoc.Remove(stoc);
                        await _context.SaveChangesAsync();
                        // setez cantitatea pt rescriere pe comanda - caz comandat>livrat
                        cantitate = stoc.Cantitate;
                    }
                    else 
                    {
                        stoc.Cantitate = cantitate;
                        _context.Stoc.Update(stoc);
                        await _context.SaveChangesAsync();
                        // setez cantitatea pt rescriere pe comanda - caz comandat=livrat
                        cantitate = Comanda.Cantitate;
                        livrata = cantitate;
                    }
                    // scriem comanda
                    Comanda.Livrata = livrata;
                    _context.Comanda.Add(Comanda);
                    await _context.SaveChangesAsync();
                    // scriem stocul comandat. Daca avem o cantitate negativa inseamna
                    // ca nu a fost suficient stocul pt cant comandata. Livram cat este
                    Stoc newStoc = new Stoc();
                    newStoc.EAN = Comanda.EAN;
                    newStoc.Produs = stoc.Produs;
                    newStoc.Furnizor = stoc.Furnizor;
                    newStoc.SSCC = stoc.SSCC;
                    newStoc.Adresa = "În curs de expediere";
                    newStoc.Client = Comanda.Client;
                    newStoc.Receptie = stoc.Receptie;
                    newStoc.Comanda = Comanda;
                    newStoc.Cantitate = Comanda.Livrata;
                    _context.Stoc.Add(newStoc);
                    await _context.SaveChangesAsync();
                    break;
                }
            }

            return RedirectToPage("../Stocuri/Index");
        }
    }
}

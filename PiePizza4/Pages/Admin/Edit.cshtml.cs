using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiePizza3.Models;

namespace PiePizza3.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly PiePizzeriaContext _context;

        public EditModel(PiePizzeriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pie Pie { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pie = await _context.Pie.FirstOrDefaultAsync(m => m.Id == id);

            if (Pie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if (Image != null)
                {
                    using (var stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        Pie.Image = stream.ToArray();
                        Pie.ImageContentType = Image.ContentType;
                    }
                }
            }

            _context.Attach(Pie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PieExists(Pie.Id))
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

        private bool PieExists(int id)
        {
            return _context.Pie.Any(e => e.Id == id);
        }
    }
}

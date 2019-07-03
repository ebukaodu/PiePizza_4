using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PiePizza3.Models;

namespace PiePizza3.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly PiePizzeriaContext _context;

        public DeleteModel(PiePizzeriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pie Pie { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pie = await _context.Pie.FindAsync(id);

            if (Pie != null)
            {
                _context.Pie.Remove(Pie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

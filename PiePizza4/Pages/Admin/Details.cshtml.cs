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
    public class DetailsModel : PageModel
    {
        private readonly PiePizzeriaContext _context;

        public DetailsModel(PiePizzeriaContext context)
        {
            _context = context;
        }

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
    }
}

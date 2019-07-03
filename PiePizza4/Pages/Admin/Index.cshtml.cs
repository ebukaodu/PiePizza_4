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
    public class IndexModel : PageModel
    {
        private readonly PiePizzeriaContext _context;

        public IndexModel(PiePizzeriaContext context)
        {
            _context = context;
        }

        public IList<Pie> Pie { get;set; }

        public async Task OnGetAsync()
        {
            Pie = await _context.Pie.ToListAsync();
        }
    }
}

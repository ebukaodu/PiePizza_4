using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PiePizza3.Models;

namespace PiePizza3.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly PiePizzeriaContext _context;

        public CreateModel(PiePizzeriaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IFormFile Image { get; set; }

        [BindProperty]
        public Pie Pie { get; set; }

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


            _context.Pie.Add(Pie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
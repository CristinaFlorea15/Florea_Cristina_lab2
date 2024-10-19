using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Florea_Cristina_Lab2.Data;
using Florea_Cristina_Lab2.Models;

namespace Florea_Cristina_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Florea_Cristina_Lab2.Data.Florea_Cristina_Lab2Context _context;

        public IndexModel(Florea_Cristina_Lab2.Data.Florea_Cristina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
            .Include(b => b.Publisher)
            .ToListAsync();
        }
    }
}

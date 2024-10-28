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
    public class DetailsModel : PageModel
    {
        private readonly Florea_Cristina_Lab2Context _context;

        public DetailsModel(Florea_Cristina_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        // Property to hold the list of category names
        public List<string> BookCategories { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Load the Book entity along with its associated categories
            Book = await _context.Book
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            // Populate the BookCategories list with the names of assigned categories
            BookCategories = Book.BookCategories
                .Select(bc => bc.Category.CategoryName)
                .ToList();

            return Page();
        }
    }
}

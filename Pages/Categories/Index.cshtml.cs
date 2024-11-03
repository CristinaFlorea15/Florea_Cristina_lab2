using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Florea_Cristina_Lab2.Data;
using Florea_Cristina_Lab2.Models;
using Florea_Cristina_Lab2.Models.ViewModels;

namespace Florea_Cristina_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Florea_Cristina_Lab2.Data.Florea_Cristina_Lab2Context _context;

        public IndexModel(Florea_Cristina_Lab2.Data.Florea_Cristina_Lab2Context context)
        {
            _context = context;
        }

        public CategoriesIndexData CategoriesData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoriesData = new CategoriesIndexData();
            CategoriesData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var selectedCategory = CategoriesData.Categories
                    .Where(c => c.ID == id.Value)
                    .SingleOrDefault();

                CategoriesData.Books = selectedCategory?.BookCategories
                    .Select(bc => bc.Book)
                    .ToList();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using Florea_Cristina_Lab2.Data;
using System.Collections.Generic;
using System.Linq;

namespace Florea_Cristina_Lab2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList { get; set; } = new List<AssignedCategoryData>();

        public void PopulateAssignedCategoryData(Florea_Cristina_Lab2Context context, Book book)
        {
            var allCategories = context.Category.ToList(); // Materialize the query
            var bookCategories = new HashSet<int>(book.BookCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var category in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = category.ID,
                    Name = category.CategoryName,
                    Assigned = bookCategories.Contains(category.ID)
                });
            }
        }

        public void UpdateBookCategories(Florea_Cristina_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            bookToUpdate.BookCategories = bookToUpdate.BookCategories ?? new List<BookCategory>();

            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories.Clear(); // Clear existing categories
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>(bookToUpdate.BookCategories.Select(c => c.Category.ID));

            foreach (var category in context.Category.ToList()) // Materialize once
            {
                if (selectedCategoriesHS.Contains(category.ID.ToString()))
                {
                    if (!bookCategories.Contains(category.ID))
                    {
                        bookToUpdate.BookCategories.Add(new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = category.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(category.ID))
                    {
                        BookCategory bookToRemove = bookToUpdate.BookCategories.SingleOrDefault(i => i.CategoryID == category.ID);
                        if (bookToRemove != null)
                        {
                            context.Remove(bookToRemove);
                        }
                    }
                }
            }
        }
    }
}

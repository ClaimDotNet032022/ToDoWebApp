using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoWebApp032022.Data;
using ToDoWebApp032022.Data.Entities;

namespace ToDoWebApp032022.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly ToDoWebApp032022.Data.ToDoDbContext _context;

        public CreateModel(ToDoWebApp032022.Data.ToDoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ParentListId"] = new SelectList(_context.ToDoLists, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ToDoItem ToDoItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ToDoItems == null || ToDoItem == null)
            {
                return Page();
            }

            _context.ToDoItems.Add(ToDoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

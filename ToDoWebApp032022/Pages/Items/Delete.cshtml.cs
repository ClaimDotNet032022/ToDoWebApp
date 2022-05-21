using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp032022.Data;
using ToDoWebApp032022.Data.Entities;

namespace ToDoWebApp032022.Pages.Items
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoWebApp032022.Data.ToDoDbContext _context;

        public DeleteModel(ToDoWebApp032022.Data.ToDoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ToDoItem ToDoItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDoItems == null)
            {
                return NotFound();
            }

            var todoitem = await _context.ToDoItems.FirstOrDefaultAsync(m => m.Id == id);

            if (todoitem == null)
            {
                return NotFound();
            }
            else 
            {
                ToDoItem = todoitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ToDoItems == null)
            {
                return NotFound();
            }
            var todoitem = await _context.ToDoItems.FindAsync(id);

            if (todoitem != null)
            {
                ToDoItem = todoitem;
                _context.ToDoItems.Remove(ToDoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp032022.Data;
using ToDoWebApp032022.Data.Entities;

namespace ToDoWebApp032022.Pages.Lists
{
    public class EditModel : PageModel
    {
        private readonly ToDoWebApp032022.Data.ToDoDbContext _context;

        public EditModel(ToDoWebApp032022.Data.ToDoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoList ToDoList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDoLists == null)
            {
                return NotFound();
            }

            var todolist =  await _context.ToDoLists.FirstOrDefaultAsync(m => m.Id == id);
            if (todolist == null)
            {
                return NotFound();
            }
            ToDoList = todolist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListExists(ToDoList.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoListExists(int id)
        {
          return (_context.ToDoLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

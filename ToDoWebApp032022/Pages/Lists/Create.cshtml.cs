using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoWebApp032022.Data;
using ToDoWebApp032022.Data.Entities;

namespace ToDoWebApp032022.Pages.Lists
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
            return Page();
        }

        [BindProperty]
        public ToDoList ToDoList { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ToDoLists == null || ToDoList == null)
            {
                return Page();
            }

            _context.ToDoLists.Add(ToDoList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

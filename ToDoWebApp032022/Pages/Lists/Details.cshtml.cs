using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoWebApp032022.Data;
using ToDoWebApp032022.Data.Entities;

namespace ToDoWebApp032022.Pages.Lists
{
    public class DetailsModel : PageModel
    {
        private readonly ToDoWebApp032022.Data.ToDoDbContext _context;

        public DetailsModel(ToDoWebApp032022.Data.ToDoDbContext context)
        {
            _context = context;
        }

      public ToDoList ToDoList { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ToDoLists == null)
            {
                return NotFound();
            }

            var todolist = await _context.ToDoLists.FirstOrDefaultAsync(m => m.Id == id);
            if (todolist == null)
            {
                return NotFound();
            }
            else 
            {
                ToDoList = todolist;
            }
            return Page();
        }
    }
}

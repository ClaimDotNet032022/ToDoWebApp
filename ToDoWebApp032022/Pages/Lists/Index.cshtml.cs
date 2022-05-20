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
    public class IndexModel : PageModel
    {
        private readonly ToDoWebApp032022.Data.ToDoDbContext _context;

        public IndexModel(ToDoWebApp032022.Data.ToDoDbContext context)
        {
            _context = context;
        }

        public IList<ToDoList> ToDoList { get;set; } = default!;

        public void OnGet()
        {
            if (_context.ToDoLists != null)
            {
                ToDoList = _context.ToDoLists.ToList();
            }
        }
    }
}

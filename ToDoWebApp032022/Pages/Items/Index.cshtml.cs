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
    public class IndexModel : PageModel
    {
        private readonly ToDoWebApp032022.Data.ToDoDbContext _context;

        public IndexModel(ToDoWebApp032022.Data.ToDoDbContext context)
        {
            _context = context;
        }

        public IList<ToDoItem> ToDoItem { get;set; } = default!;

        public async Task OnGetAsync(int? listId)
        {
            if (_context.ToDoItems != null)
            {
                ToDoItem = await _context.ToDoItems
                    .Include(t => t.ParentList)
                    .Where(i => i.ParentListId == listId)
                    .ToListAsync();

                //ToDoList list = _context.ToDoLists
                //    .Include(l => l.Items)
                //    .Single(l => l.Id == listId);
                //ToDoItem = list.Items;
            }
        }
    }
}

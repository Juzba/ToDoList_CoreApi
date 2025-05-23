using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList_CoreApi.Data;
using ToDoList_CoreApi.Models;

namespace ToDoList_CoreApi.Areas.Editor.Pages
{
    public class DetailsModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        public TaskModel TaskModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskmodel = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);

            if (taskmodel is not null)
            {
                TaskModel = taskmodel;

                return Page();
            }

            return NotFound();
        }
    }
}

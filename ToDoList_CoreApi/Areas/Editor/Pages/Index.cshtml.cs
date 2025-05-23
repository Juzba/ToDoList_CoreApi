using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList_CoreApi.Data;
using ToDoList_CoreApi.Models;

namespace ToDoList_CoreApi.Areas.Editor.Pages
{
    public class IndexModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        public IList<TaskModel> TaskModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //TaskModel = await _context.Tasks.ToListAsync();
            TaskModel = await _context.Tasks.OrderBy(p => p.IsCompleted).ThenBy(p=>p.DueDate).ToListAsync();
        }
    }
}

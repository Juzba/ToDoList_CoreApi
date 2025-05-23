using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList_CoreApi.Data;
using ToDoList_CoreApi.Models;

namespace ToDoList_CoreApi.Areas.Editor.Pages
{
    public class IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager ) : PageModel
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public IList<TaskModel> TaskModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            TaskModel = await _context.Tasks
                .Where(p=>p.UserId == _userManager.GetUserId(User))
                .OrderBy(p => p.IsCompleted)
                .ThenBy(p=>p.DueDate)
                .ToListAsync();
        }
    }
}

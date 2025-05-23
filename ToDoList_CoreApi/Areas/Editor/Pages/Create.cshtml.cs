using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList_CoreApi.Data;
using ToDoList_CoreApi.Models;

namespace ToDoList_CoreApi.Pages.ToDoList
{
    public class CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager) : PageModel
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskModel TaskModel { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TaskModel.UserId = _userManager.GetUserId(User)!; 
            _context.Tasks.Add(TaskModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

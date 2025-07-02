using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Pages;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public Todo NewTodo { get; set; } = new();

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _context.Todos.Add(NewTodo);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Pages;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public Todo Todos { get; set; } = default!;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Todo? todo = await _context.Todos.FindAsync(id);

        if (todo == null) return NotFound();

        Todos = todo;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var todo = await _context.Todos.FindAsync(Todos.Id);

        if (todo == null) return NotFound();

        _context.Todos.Remove(todo);

        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
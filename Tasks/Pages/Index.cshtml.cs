using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public List<Todo> Todos { get; set; } = [];

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    // Listagem de todos os ToDos
    public async Task OnGetAsync()
    {
        Todos = await _context.Todos
            .OrderBy(t => t.IsDone)
            .ThenByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    // Exclusão de todas as tarefas
    public async Task<IActionResult> OnPostDeleteAllAsync()
    {
        
        var allTodos = await _context.Todos.ToListAsync();

        if (allTodos.Any())
        {
            _context.Todos.RemoveRange(allTodos);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("Index");
    }
}
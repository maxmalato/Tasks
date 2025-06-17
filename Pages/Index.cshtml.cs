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

    public async Task OnGetAsync()
    {
        Todos = await _context.Todos
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }
}
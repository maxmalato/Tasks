using System.ComponentModel.DataAnnotations;

namespace Tasks.Models;

public class Todo
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "{0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "Deve ter no máximo 100 caracteres.")]
    [Display(Name = "Título")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "{0} é obrigatória.")]
    [StringLength(300, ErrorMessage = "Deve ter no máximo 300 caracteres.")]
    [Display(Name = "Descrição")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Concluído")]
    public bool IsDone { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

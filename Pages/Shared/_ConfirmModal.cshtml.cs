using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tasks.Pages.Shared;

public class _ConfirmModalModel : PageModel
{
    public string ModalId { get; set; } = "modalConfirm";
    public string Title { get; set; } = "Confirmar Ação";
    public string Message { get; set; } = "Você tem certeza que deseja continuar?";
    public string Handler { get; set; } = "DeleteAll";
    public string ConfirmButtonText { get; set; } = "Confirmar";
    public string ConfirmButtonColor { get; set; } = "danger";
    public string HeaderColor { get; set; } = "warning";
}

using Client.Components;

namespace Client.Services;

/// <summary>
/// Servicio para mostrar notificaciones Toast
/// </summary>
public class ToastService : IToastService
{
    public event Action<string, AlertType, string>? OnShow;

    public void ShowSuccess(string message, string title = "Éxito")
    {
        OnShow?.Invoke(message, AlertType.Success, title);
    }

    public void ShowError(string message, string title = "Error")
    {
        OnShow?.Invoke(message, AlertType.Danger, title);
    }

    public void ShowWarning(string message, string title = "Advertencia")
    {
        OnShow?.Invoke(message, AlertType.Warning, title);
    }

    public void ShowInfo(string message, string title = "Información")
    {
        OnShow?.Invoke(message, AlertType.Info, title);
    }
}


using Client.Components;

namespace Client.Services;

/// <summary>
/// Interfaz para el servicio de notificaciones Toast
/// </summary>
public interface IToastService
{
    /// <summary>
    /// Muestra una notificación de éxito
    /// </summary>
    /// <param name="message">Mensaje a mostrar</param>
    /// <param name="title">Título de la notificación (por defecto "Éxito")</param>
    void ShowSuccess(string message, string title = "Éxito");

    /// <summary>
    /// Muestra una notificación de error
    /// </summary>
    /// <param name="message">Mensaje a mostrar</param>
    /// <param name="title">Título de la notificación (por defecto "Error")</param>
    void ShowError(string message, string title = "Error");

    /// <summary>
    /// Muestra una notificación de advertencia
    /// </summary>
    /// <param name="message">Mensaje a mostrar</param>
    /// <param name="title">Título de la notificación (por defecto "Advertencia")</param>
    void ShowWarning(string message, string title = "Advertencia");

    /// <summary>
    /// Muestra una notificación informativa
    /// </summary>
    /// <param name="message">Mensaje a mostrar</param>
    /// <param name="title">Título de la notificación (por defecto "Información")</param>
    void ShowInfo(string message, string title = "Información");

    /// <summary>
    /// Evento que se dispara cuando se muestra una notificación
    /// </summary>
    event Action<string, AlertType, string> OnShow;
}


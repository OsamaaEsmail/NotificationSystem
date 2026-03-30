using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Interfaces;

// separate interface just for LOGGING — not mixed with sending
// Interface Segregation: if a class only needs logging, it takes this only
public interface INotificationLogger
{
    void Log(NotificationMessage message, bool success);
}


using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Interfaces;

// BAD — violates Interface Segregation
public interface INotificationService
{
    bool Send(NotificationMessage message);
    void Log(NotificationMessage message, bool success);
    string Format(NotificationMessage message);
}
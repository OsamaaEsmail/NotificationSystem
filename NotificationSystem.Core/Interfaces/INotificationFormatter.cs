using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Interfaces;

// separate interface just for FORMATTING the message body
// Email might want HTML, SMS wants plain short text, Push wants a title
public interface INotificationFormatter
{
    string Format(NotificationMessage message);
}
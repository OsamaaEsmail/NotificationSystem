using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Formatters;

// Single Responsibility: ONLY formats messages for email (HTML style)
public class EmailFormatter : INotificationFormatter
{
    public string Format(NotificationMessage message)
        => $"<h1>{message.Subject}</h1><p>{message.Body}</p>";
}
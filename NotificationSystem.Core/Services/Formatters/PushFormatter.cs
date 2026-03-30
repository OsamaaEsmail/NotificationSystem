using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Formatters;

// Single Responsibility: ONLY formats messages for push (title + short body)
public class PushFormatter : INotificationFormatter
{
    public string Format(NotificationMessage message)
        => $"{message.Subject}: {message.Body}";
}
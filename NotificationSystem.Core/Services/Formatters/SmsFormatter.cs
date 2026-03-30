using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Formatters;

// Single Responsibility: ONLY formats messages for SMS (short plain text)
public class SmsFormatter : INotificationFormatter
{
    public string Format(NotificationMessage message)
        => message.Body.Length > 160
            ? message.Body[..157] + "..."   // SMS limit is 160 chars
            : message.Body;
}
using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Logging;

// Single Responsibility: ONLY logs notification results to console
public class ConsoleNotificationLogger : INotificationLogger
{
    public void Log(NotificationMessage message, bool success)
    {
        var status = success ? "SUCCESS" : "FAILED";
        Console.WriteLine($"    [LOG] {status} | {message.Type} to {message.Recipient} at {message.CreatedAt:HH:mm:ss}");
    }
}


using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;
// this is Open/Closed Principle
//Without touching ConsoleNotificationLogger — just create a new class. That's Open/Closed: open for extension (new class), closed for modification (existing code stays untouched).

namespace NotificationSystem.Core.Services.Formatters;

public class DatabaseNotificationLogger : INotificationLogger
{
    public void Log(NotificationMessage message, bool success)
    {
        // save to database
    }
}
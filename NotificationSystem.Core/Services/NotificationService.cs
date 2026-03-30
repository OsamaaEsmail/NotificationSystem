using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services;

// Dependency Inversion: depends on INTERFACES not concrete classes
// this class has NO idea what EmailChannel or SmsChannel is
// it only knows INotificationChannel, INotificationFormatter, INotificationLogger
public class NotificationService
{
    // injected from outside — not created here (DIP)
    private readonly INotificationChannel _channel;
    private readonly INotificationFormatter _formatter;
    private readonly INotificationLogger _logger;

    // constructor receives interfaces — not concrete classes
    public NotificationService(
        INotificationChannel channel,
        INotificationFormatter formatter,
        INotificationLogger logger)
    {
        _channel = channel;
        _formatter = formatter;
        _logger = logger;
    }

    public void Send(NotificationMessage message)
    {
        // 1. format the message
        var formatted = _formatter.Format(message);
        Console.WriteLine($"    [Formatted] {formatted}");

        // 2. send through the channel
        var success = _channel.Send(message);

        // 3. update status
        if (success)
            message.MarkAsSent();
        else
            message.MarkAsFailed();

        // 4. log the result
        _logger.Log(message, success);
    }
}
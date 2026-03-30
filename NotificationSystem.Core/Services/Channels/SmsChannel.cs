using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Channels;

// Single Responsibility: this class ONLY knows how to send SMS
public class SmsChannel : INotificationChannel
{
    public string ChannelName => "SMS";

    public bool Send(NotificationMessage message)
    {
        Console.WriteLine($"    [SMS] Sending to {message.Recipient}: {message.Body}");
        return true;
    }
}
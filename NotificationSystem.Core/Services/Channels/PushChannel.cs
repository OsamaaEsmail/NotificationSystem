using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Channels;

// Single Responsibility: this class ONLY knows how to send Push notifications
public class PushChannel : INotificationChannel
{
    public string ChannelName => "Push";

    public bool Send(NotificationMessage message)
    {
        Console.WriteLine($"    [Push] Sending to {message.Recipient}: {message.Subject}");
        return true;
    }
}
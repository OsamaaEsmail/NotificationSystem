

using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Channels;

// this is Open/Closed Principle
public class SlackChannel : INotificationChannel
{
    public string ChannelName => "Slack";

    public bool Send(NotificationMessage message)
    {
        Console.WriteLine($"    [Slack] Sending to {message.Recipient}: {message.Body}");
        return true;
    }
}
using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Services.Channels;

// Single Responsibility: this class ONLY knows how to send emails
public class EmailChannel : INotificationChannel
{
    public string ChannelName => "Email";

    public bool Send(NotificationMessage message)
    {
        // simulate sending email
        Console.WriteLine($"    [Email] Sending to {message.Recipient}: {message.Subject}");
        return true;  // simulate success
    }
}
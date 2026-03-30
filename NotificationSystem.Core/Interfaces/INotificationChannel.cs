using NotificationSystem.Core.Models;

namespace NotificationSystem.Core.Interfaces;

// this is the contract for SENDING notifications
// each channel (Email, SMS, Push) implements this differently
// used in: Open/Closed + Liskov + Dependency Inversion
public interface INotificationChannel
{
    string ChannelName { get; }  // "Email", "SMS", "Push"
    bool Send(NotificationMessage message);
}
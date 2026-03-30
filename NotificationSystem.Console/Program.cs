using NotificationSystem.Core.Enums;
using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;
using NotificationSystem.Core.Services.Channels;


// === OPEN/CLOSED + LISKOV SUBSTITUTION ===

Console.WriteLine("\n=== OCP + LSP: Different channels, same interface ===\n");

// create all channels
var emailChannel = new EmailChannel();
var smsChannel = new SmsChannel();
var pushChannel = new PushChannel();

// Liskov: all of them are INotificationChannel — swap any one and it works
List<INotificationChannel> channels = [emailChannel, smsChannel, pushChannel];

var testMessage = new NotificationMessage(
    "ahmed@gmail.com",
    "Test",
    "Hello from all channels!",
    NotificationType.Email);

foreach (var channel in channels)
{
    Console.WriteLine($"  Channel: {channel.ChannelName}");
    channel.Send(testMessage);
}
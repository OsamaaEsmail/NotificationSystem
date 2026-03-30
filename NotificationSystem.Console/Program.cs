using NotificationSystem.Core.Enums;
using NotificationSystem.Core.Interfaces;
using NotificationSystem.Core.Models;
using NotificationSystem.Core.Services;
using NotificationSystem.Core.Services.Channels;
using NotificationSystem.Core.Services.Formatters;
using NotificationSystem.Core.Services.Logging;

// ============================================================
// 1. SRP: NotificationMessage only holds data
// ============================================================
Console.WriteLine("=== SRP: NotificationMessage only holds data ===\n");

var message = new NotificationMessage(
    "ahmed@gmail.com",
    "Welcome!",
    "Thanks for joining our platform.",
    NotificationType.Email);

Console.WriteLine(message);
Console.WriteLine($"  Status: {message.Status}");

message.MarkAsSent();
Console.WriteLine($"  After MarkAsSent(): {message.Status}");

// ============================================================
// 2. OCP + LSP: Different channels, same interface
// ============================================================
Console.WriteLine("\n=== OCP + LSP: Different channels, same interface ===\n");

var emailChannel = new EmailChannel();
var smsChannel = new SmsChannel();
var pushChannel = new PushChannel();

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

// ============================================================
// 3. ISP: Each interface has one job
// ============================================================
Console.WriteLine("\n=== ISP: Each interface has one job ===\n");

var emailFormatter = new EmailFormatter();
var smsFormatter = new SmsFormatter();
var pushFormatter = new PushFormatter();

var emailMsg = new NotificationMessage(
    "sara@gmail.com",
    "Welcome Sara",
    "Thanks for joining us today!",
    NotificationType.Email);

Console.WriteLine($"  Email format: {emailFormatter.Format(emailMsg)}");
Console.WriteLine($"  SMS format:   {smsFormatter.Format(emailMsg)}");
Console.WriteLine($"  Push format:  {pushFormatter.Format(emailMsg)}");

Console.WriteLine();
var logger = new ConsoleNotificationLogger();
logger.Log(emailMsg, true);
logger.Log(emailMsg, false);

// ============================================================
// 4. DIP: NotificationService depends on interfaces
// ============================================================
Console.WriteLine("\n=== DIP: NotificationService depends on interfaces ===\n");

// --- Send via Email ---
Console.WriteLine("  Sending Email:");
var emailService = new NotificationService(
    new EmailChannel(),
    new EmailFormatter(),
    new ConsoleNotificationLogger()
);

var emailNotification = new NotificationMessage(
    "ahmed@gmail.com",
    "Welcome!",
    "Thanks for joining our platform.",
    NotificationType.Email);

emailService.Send(emailNotification);
Console.WriteLine($"  Status: {emailNotification.Status}");

// --- Send via SMS ---
Console.WriteLine("\n  Sending SMS:");
var smsService = new NotificationService(
    new SmsChannel(),
    new SmsFormatter(),
    new ConsoleNotificationLogger()
);

var smsNotification = new NotificationMessage(
    "01012345678",
    "Code",
    "Your verification code is 5821",
    NotificationType.Sms);

smsService.Send(smsNotification);
Console.WriteLine($"  Status: {smsNotification.Status}");

// --- Send via Push ---
Console.WriteLine("\n  Sending Push:");
var pushService = new NotificationService(
    new PushChannel(),
    new PushFormatter(),
    new ConsoleNotificationLogger()
);

var pushNotification = new NotificationMessage(
    "device-token-abc",
    "New Message",
    "You have a new message from Sara",
    NotificationType.Push);

pushService.Send(pushNotification);
Console.WriteLine($"  Status: {pushNotification.Status}");

Console.WriteLine("\n=== Done! ===");
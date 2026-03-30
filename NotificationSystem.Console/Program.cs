// === DEPENDENCY INVERSION ===

using NotificationSystem.Core.Enums;
using NotificationSystem.Core.Models;
using NotificationSystem.Core.Services;
using NotificationSystem.Core.Services.Channels;
using NotificationSystem.Core.Services.Formatters;
using NotificationSystem.Core.Services.Logging;

Console.WriteLine("\n=== DIP: NotificationService depends on interfaces ===\n");

// --- Send via Email ---
Console.WriteLine("  Sending Email:");
var emailService = new NotificationService(
    new EmailChannel(),        // INotificationChannel
    new EmailFormatter(),      // INotificationFormatter
    new ConsoleNotificationLogger()  // INotificationLogger
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
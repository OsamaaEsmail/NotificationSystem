using NotificationSystem.Core.Enums;
using NotificationSystem.Core.Models;


// === SINGLE RESPONSIBILITY PRINCIPLE ===

Console.WriteLine("=== SRP: NotificationMessage only holds data ===\n");

var message = new NotificationMessage(
    "ahmed@gmail.com",
    "Welcome!",
    "Thanks for joining our platform.",
    NotificationType.Email);

Console.WriteLine(message);
Console.WriteLine($"  Status: {message.Status}");  // Pending

message.MarkAsSent();
Console.WriteLine($"  After MarkAsSent(): {message.Status}");  // Sent

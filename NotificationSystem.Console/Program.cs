using NotificationSystem.Core.Enums;
using NotificationSystem.Core.Models;
using NotificationSystem.Core.Services.Formatters;
using NotificationSystem.Core.Services.Logging;

// === INTERFACE SEGREGATION ===

Console.WriteLine("\n=== ISP: Each interface has one job ===\n");

// Formatter only formats — doesn't send, doesn't log
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

// Logger only logs — doesn't send, doesn't format
Console.WriteLine();
var logger = new ConsoleNotificationLogger();
logger.Log(emailMsg, true);
logger.Log(emailMsg, false);
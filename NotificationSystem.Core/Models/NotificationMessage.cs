using NotificationSystem.Core.Enums;

namespace NotificationSystem.Core.Models;

// simple data container — holds the notification info
// Single Responsibility: this class ONLY holds data, nothing else
public class NotificationMessage
{
    public Guid Id { get; }
    public string Recipient { get; }      // email address, phone number, or device token
    public string Subject { get; }        // title of the notification
    public string Body { get; }           // the actual message content
    public NotificationType Type { get; } // Email, SMS, or Push
    public NotificationStatus Status { get; private set; }  // Pending, Sent, Failed
    public DateTime CreatedAt { get; }

    public NotificationMessage(string recipient, string subject, string body, NotificationType type)
    {
        if (string.IsNullOrWhiteSpace(recipient))
            throw new ArgumentException("Recipient cannot be empty.");

        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentException("Body cannot be empty.");

        Id = Guid.NewGuid();
        Recipient = recipient;
        Subject = subject;
        Body = body;
        Type = type;
        Status = NotificationStatus.Pending;  // always starts as Pending
        CreatedAt = DateTime.UtcNow;
    }

    // only way to change status — controlled from inside (Encapsulation)
    public void MarkAsSent() => Status = NotificationStatus.Sent;
    public void MarkAsFailed() => Status = NotificationStatus.Failed;

    public override string ToString()
        => $"[{Type}] To: {Recipient} | Status: {Status} | Subject: {Subject}";
}
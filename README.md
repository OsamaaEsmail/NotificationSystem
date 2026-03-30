# NotificationSystem — SOLID Principles Demo

A minimal .NET 9 project demonstrating the five SOLID principles through a Notification System domain (Email, SMS, Push). Class Library + Console App.

## Project Structure
```
NotificationSystem/
├── NotificationSystem.Core/
│   ├── Enums/
│   │   ├── NotificationType.cs
│   │   └── NotificationStatus.cs
│   ├── Interfaces/
│   │   ├── INotificationChannel.cs
│   │   ├── INotificationFormatter.cs
│   │   └── INotificationLogger.cs
│   ├── Models/
│   │   └── NotificationMessage.cs
│   └── Services/
│       ├── Channels/
│       │   ├── EmailChannel.cs
│       │   ├── SmsChannel.cs
│       │   └── PushChannel.cs
│       ├── Formatters/
│       │   ├── EmailFormatter.cs
│       │   ├── SmsFormatter.cs
│       │   └── PushFormatter.cs
│       ├── Logging/
│       │   └── ConsoleNotificationLogger.cs
│       └── NotificationService.cs
└── NotificationSystem.Console/
    └── Program.cs
```

## SOLID Principles Covered

| Principle | Where | How |
|-----------|-------|-----|
| **S — Single Responsibility** | Every class | `NotificationMessage` only holds data. `EmailChannel` only sends emails. `ConsoleNotificationLogger` only logs. Each class has one reason to change. |
| **O — Open/Closed** | Channels, Formatters, Loggers | Add a new channel (Slack, WhatsApp) by creating a new class that implements `INotificationChannel`. No existing code needs to change. |
| **L — Liskov Substitution** | All `INotificationChannel` implementations | Any channel can replace another — `EmailChannel`, `SmsChannel`, `PushChannel` are all interchangeable through the interface. |
| **I — Interface Segregation** | `INotificationChannel`, `INotificationFormatter`, `INotificationLogger` | Three small focused interfaces instead of one big interface. Each class only implements what it actually needs. |
| **D — Dependency Inversion** | `NotificationService` | Depends on interfaces (`INotificationChannel`, `INotificationFormatter`, `INotificationLogger`) not concrete classes. Dependencies are injected via constructor. |


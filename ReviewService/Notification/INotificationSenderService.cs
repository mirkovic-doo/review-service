namespace ReviewService.Notification;

public interface INotificationSenderService
{
    void Send(NotificationPayload payload);
}

namespace ReviewService.Notification;

public interface INotificationSender
{
    void Send(NotificationPayload payload);
}

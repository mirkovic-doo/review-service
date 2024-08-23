namespace ReviewService.Notification;

public class NotificationPayload
{
    public Guid SenderId { get; set; }
    public Guid RecieverId { get; set; }
    public Guid EntityId { get; set; }
    public NotificationType Type { get; set; }
}

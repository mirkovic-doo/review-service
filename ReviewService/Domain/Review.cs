using ReviewService.Domain.Base;

namespace ReviewService.Domain;

public class Review : Entity, IEntity, IAuditedEntity
{
    public Review()
    {
        Comment = string.Empty;
    }

    public Review(Guid reservationId, Guid propertyId, ReviewType type, string comment, double rating) : base()
    {
        Rating = rating;
        Comment = comment;
        Type = type;
        RevieweeId = propertyId;
        ReservationId = reservationId;
    }

    public Guid ReservationId { get; set; }
    public Guid RevieweeId { get; set; }
    public ReviewType Type { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }
}

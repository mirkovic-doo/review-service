using ReviewService.Domain.Base;

namespace ReviewService.Domain;

public class Review : Entity, IEntity, IAuditedEntity
{
    public Review()
    {
        Comment = string.Empty;
    }

    public Review(Guid reservationId, Guid propertyId, string comment, double rating) : base()
    {
        ReservationId = reservationId;
        PropertyId = propertyId;
        Comment = comment;
        Rating = rating;
    }

    public Guid ReservationId { get; set; }
    public Guid PropertyId { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }
}

using AutoMapper;
using ReviewService.Controllers.Review.Requests;
using ReviewService.Controllers.Review.Responses;
using ReviewService.Domain;

namespace ReviewService.Contracts.MappingProfiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewRequest, Review>();
        CreateMap<Review, ReviewResponse>();
    }
}

using AutoMapper;
using ReviewService.Contracts.Data;
using ReviewService.Controllers.Review.Requests;
using ReviewService.Controllers.Review.Responses;
using ReviewService.Domain;

namespace ReviewService.Contracts.MappingProfiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewRequest, Review>();
        CreateMap<UpdateReviewRequest, UpdateReviewInput>();
        CreateMap<UpdateReviewInput, Review>();
        CreateMap<Review, ReviewResponse>();
    }
}

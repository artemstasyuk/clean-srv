using FluentValidation;

namespace CatStore.Application.MediaR.Cats.Queries.GetCatById;

public class GetCatByIdQueryValidator : AbstractValidator<GetCatByIdQuery>
{
    public GetCatByIdQueryValidator()
    {
        RuleFor(q => q.Id).NotEmpty();
    }
}
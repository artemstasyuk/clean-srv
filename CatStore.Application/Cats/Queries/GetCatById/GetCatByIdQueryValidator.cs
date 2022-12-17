using FluentValidation;

namespace CatStore.Application.Cats.Queries.GetCatById;

public class GetCatByIdQueryValidator : AbstractValidator<GetCatByIdQuery>
{
    public GetCatByIdQueryValidator()
    {
        RuleFor(q => q.Id).NotEmpty();
    }
}
using FluentValidation;

namespace CatStore.Application.Orders.Queries.GetAllUserOrders;

public class GetAllUserOrdersQueryValidator: AbstractValidator<GetAllUserOrdersQuery>
{
    public GetAllUserOrdersQueryValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}
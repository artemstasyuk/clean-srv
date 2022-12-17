using FluentValidation;

namespace CatStore.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidation()
    {
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.HouseNumber).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}
using FluentValidation;

namespace CatStore.Application.Cats.Commands.DeleteCat;

public class DeleteCatCommandValidator : AbstractValidator<DeleteCatCommand>
{
   public DeleteCatCommandValidator()
   {
      RuleFor(c => c.Id).NotEmpty();
   }
}
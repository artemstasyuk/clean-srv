using FluentValidation;

namespace CatStore.Application.MediaR.Cats.Commands.DeleteCat;

public class DeleteCatCommandValidator : AbstractValidator<DeleteCatCommand>
{
   public DeleteCatCommandValidator()
   {
      RuleFor(c => c.Id).NotEmpty();
   }
}
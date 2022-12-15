namespace CatStore.Application.Dtos.Cat;

public class CatListDto 
{
    public List<Domain.CatAggregate.Cat> Cats { get; set; }
}
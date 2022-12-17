using CatStore.Application.Common.Interfaces.Persistence;
using CatStore.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.UserManagement.Queries.GetAllUsersQuery;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<List<User>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<User>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetListAsync();
        return users ;
    }
}
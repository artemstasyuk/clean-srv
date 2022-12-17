using CatStore.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CatStore.Application.UserManagement.Queries.GetAllUsersQuery;

public class GetAllUsersQuery : IRequest<ErrorOr<List<User>>>
{
}
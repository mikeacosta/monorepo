using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Gimmicks.Queries;

public class GetGimmicksList
{
    public class Query : IRequest<List<Gimmick>> {}

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Gimmick>>
    {
        public async Task<List<Gimmick>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Gimmicks.ToListAsync(cancellationToken);
        }
    }
}
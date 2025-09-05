using Domain;
using MediatR;
using Persistence;

namespace Application.Gimmicks.Queries;

public class GetGimmickDetails
{
    public class Query : IRequest<Gimmick>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Gimmick>
    {
        public async Task<Gimmick> Handle(Query request, CancellationToken cancellationToken)
        {
            var gimmick = await context.Gimmicks.FindAsync([request.Id], cancellationToken);
            
            if (gimmick == null)
                throw new Exception("Gimmick not found");
            
            return gimmick;
        }
    }
}
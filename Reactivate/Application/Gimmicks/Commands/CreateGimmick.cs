using Domain;
using MediatR;
using Persistence;

namespace Application.Gimmicks.Commands;

public class CreateGimmick
{
    public class Command : IRequest<string>
    {
        public required Gimmick Gimmick { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Gimmicks.Add(request.Gimmick);
            
            await context.SaveChangesAsync(cancellationToken);

            return request.Gimmick.Id;
        }
    }
}
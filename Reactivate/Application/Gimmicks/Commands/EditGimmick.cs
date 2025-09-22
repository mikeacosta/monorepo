using Domain;
using MediatR;
using Persistence;

namespace Application.Gimmicks.Commands;

public class EditGimmick
{
    public class Command : IRequest
    {
        public required Gimmick Gimmick { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var gimmick = await context.Gimmicks
                .FindAsync([request.Gimmick.Id], cancellationToken)
                ?? throw new Exception("Gimmick not found");
            
            gimmick.Title = request.Gimmick.Title;
            
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
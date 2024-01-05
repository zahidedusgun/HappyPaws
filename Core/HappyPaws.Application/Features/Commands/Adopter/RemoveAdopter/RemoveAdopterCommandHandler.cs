using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Persistence.Contexts;

namespace HappyPaws.Application.Features.Commands.Adopter.RemoveAdopter
{
    public class RemoveAdopterCommandHandler : IRequestHandler<RemoveAdopterCommandRequest, RemoveAdopterCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public RemoveAdopterCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RemoveAdopterCommandResponse> Handle(RemoveAdopterCommandRequest request, CancellationToken cancellationToken)
        {
            var removeAdopter = _context.Adopters.FirstOrDefault(x => x.Id == request.AdopterId);
            _context.Adopters.Remove(removeAdopter);

            return new RemoveAdopterCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}

using HappyPaws.Application.Features.Commands.Pet.RemovePet;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Pet.RemovePet
{
    public class RemovePetCommandHandler : IRequestHandler<RemovePetCommandRequest, RemovePetCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public RemovePetCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RemovePetCommandResponse> Handle(RemovePetCommandRequest request, CancellationToken cancellationToken)
        {
            var removePet =
                _context.Pets.FirstOrDefault(pet =>
                    pet.Id == request.Id);
            _context.Pets.Remove(removePet);
            return new RemovePetCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}

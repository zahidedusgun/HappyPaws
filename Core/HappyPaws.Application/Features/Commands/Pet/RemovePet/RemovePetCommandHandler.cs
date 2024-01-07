using HappyPaws.Application.Features.Commands.Adopter.RemoveAdopter;
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

            Domain.Entities.Pet? removePet = _context.Pets.FirstOrDefault(x => x.Id == request.PetId);
            _context.Pets.Remove(removePet);

            if (removePet is not null)
            {
                await _context.SaveChangesAsync();
                return new RemovePetCommandResponse
                {
                    IsSuccess = true
                };
            }
            else return new RemovePetCommandResponse { IsSuccess = false };
        }
    }
}

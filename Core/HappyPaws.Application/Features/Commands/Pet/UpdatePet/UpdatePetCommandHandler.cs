using HappyPaws.Application.Features.Commands.HealthRecord.UpdateHealthRecord;
using HappyPaws.Application.Features.Commands.Pet.UpdatePet;
using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Pet.UpdatePet
{
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommandRequest, UpdatePetCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePetCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdatePetCommandResponse> Handle(UpdatePetCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Pet? pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id.ToString() == request.PetId);

            if (pet is not null)
            {
                pet.Name = request.Name;
                pet.Type = request.Type;
                pet.Age = request.Age;

                await _context.SaveChangesAsync();

                return new UpdatePetCommandResponse
                {
                    IsSuccess = true
                };
            }
            else return new UpdatePetCommandResponse { IsSuccess = false };
        }
    }
}

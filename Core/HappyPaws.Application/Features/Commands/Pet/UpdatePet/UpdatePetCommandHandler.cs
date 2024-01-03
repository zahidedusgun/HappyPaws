using HappyPaws.Application.Features.Commands.Pet.UpdatePet;
using HappyPaws.Persistence.Contexts;
using MediatR;
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
            try
            {
                var pet = await _context.Pets.FindAsync(Guid.Parse(request.Id));

                if (pet == null)
                {
                    return new UpdatePetCommandResponse { IsSuccess = false };
                }

                pet.Name = request.Name;
                pet.Type = request.Type;
                pet.Age = request.Age;


                await _context.SaveChangesAsync();

                return new UpdatePetCommandResponse { IsSuccess = true };
            }
            catch (Exception)
            {
                return new UpdatePetCommandResponse { IsSuccess = false };
            }
        }
    }
}

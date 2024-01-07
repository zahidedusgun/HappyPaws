using HappyPaws.Application.Features.Commands.Adoption.CreateAdoption;
using HappyPaws.Application.Features.Commands.Pet.CreatePet;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adoption.CreateAdoption
{
    public class CreateAdoptionCommandHandler : IRequestHandler<CreateAdoptionCommandRequest, CreateAdoptionCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreateAdoptionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateAdoptionCommandResponse> Handle(CreateAdoptionCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Adopter? adopter = _context.Adopters.FirstOrDefault(a => a.Id == request.AdopterId);
            Domain.Entities.Pet? pet = _context.Pets.FirstOrDefault(b => b.Id == request.PetId);

            if (adopter != null)
            {
                var id = Guid.NewGuid();
                _context.Adoptions.Add(new()
                {
                    AdoptionDate = DateTime.UtcNow,
                    AdoptionNotes = request.AdoptionNotes,
                    AdoptionStatus = request.AdoptionStatus,
                    CreatedByUserId = "halaymaster",
                    IsDeleted = false,
                    AdopterId = request.AdopterId,
                    PetId = request.PetId

                });

                await _context.SaveChangesAsync();

                return new CreateAdoptionCommandResponse
                {
                    IsSuccess = true,
                    AdoptionId = id
                };
            }
            else return new CreateAdoptionCommandResponse
            {
                IsSuccess = false
            };

        }
    }
}
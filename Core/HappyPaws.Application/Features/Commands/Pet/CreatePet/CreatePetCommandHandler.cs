using HappyPaws.Application.Features.Commands.Pet.CreatePet;
using HappyPaws.Domain.Enums;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Pet.CreatePet
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommandRequest, CreatePetCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreatePetCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreatePetCommandResponse> Handle(CreatePetCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Adopter? adopter = _context.Adopters.FirstOrDefault(a => a.Id == request.AdopterId);

            if (adopter is not null)

            {
                var id = Guid.NewGuid();
                _context.Pets.Add(new()
                {
                    Name = request.Name,
                    Type = request.Type,
                    Breed = request.Breed,
                    Age = request.Age,
                    Gender = request.Gender,
                    CreatedByUserId = "halaymaster",
                    IsDeleted = false,
                    AdopterId = request.AdopterId
                });

                await _context.SaveChangesAsync();

                return new CreatePetCommandResponse
                {
                    IsSuccess = true,
                    PetId = id
                };
            }
            else return new CreatePetCommandResponse
            {
                IsSuccess = false
            };


        }
    }
}
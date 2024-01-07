using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using HappyPaws.Application.Features.Commands.Pet.CreatePet;

namespace HappyPaws.Application.Features.Commands.HealthRecord.CreateHealthRecord
{
    public class CreateHealthRecordCommandHandler : IRequestHandler<CreateHealthRecordCommandRequest, CreateHealthRecordCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public CreateHealthRecordCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateHealthRecordCommandResponse> Handle(CreateHealthRecordCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Pet? pet = _context.Pets.FirstOrDefault(a => a.Id == request.PetId);

            if (pet is not null)

            {
                var id = Guid.NewGuid();
                _context.HealthRecords.Add(new()
                {
                    RecordDate = DateTime.UtcNow,
                    Description = request.Description,
                    VetVisitDate = request.VetVisitDate,
                    VetNotes = request.VetNotes,
                    CreatedByUserId = "halaymaster",
                    IsDeleted = false,
                    PetId = request.PetId
                });

                await _context.SaveChangesAsync();


                return new CreateHealthRecordCommandResponse
                {
                    IsSuccess = true,
                    HealthRecordId = id
                };
            }
            else return new CreateHealthRecordCommandResponse
            {
                IsSuccess = false
            };

        }
    }
}
using HappyPaws.Application.Features.Commands.Adoption.CreateAdoption;
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
            var id = Guid.NewGuid();
            _context.Adoptions.Add(new()
            {
                AdoptionDate = DateTime.UtcNow,
                AdoptionNotes = request.AdoptionNotes,
                AdoptionStatus = request.AdoptionStatus,
            });

            await _context.SaveChangesAsync();

            return new CreateAdoptionCommandResponse
            {
                IsSuccess = true,
                AdoptionId = id
            };
        }
    }
}

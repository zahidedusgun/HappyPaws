using HappyPaws.Application.Features.Commands.Adopter.RemoveAdopter;
using HappyPaws.Application.Features.Commands.Adoption.RemoveAdoption;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adoption.RemoveAdoption
{
    public class RemoveAdoptionCommandHandler : IRequestHandler<RemoveAdoptionCommandRequest, RemoveAdoptionCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public RemoveAdoptionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RemoveAdoptionCommandResponse> Handle(RemoveAdoptionCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Adoption? removeAdoption = _context.Adoptions.FirstOrDefault(x => x.Id == request.AdoptionId);
            _context.Adoptions.Remove(removeAdoption);

            if (removeAdoption is not null)
            {
                await _context.SaveChangesAsync();
                return new RemoveAdoptionCommandResponse
                {
                    IsSuccess = true
                };
            }
            else return new RemoveAdoptionCommandResponse { IsSuccess = false };
        }
    }
}

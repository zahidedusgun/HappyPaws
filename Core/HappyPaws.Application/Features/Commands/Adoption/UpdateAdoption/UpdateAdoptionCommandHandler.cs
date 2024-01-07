using HappyPaws.Application.Features.Commands.Adopter.UpdateAdopter;
using HappyPaws.Application.Features.Commands.Adoption.UpdateAdoption;
using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adoption.UpdateAdoption
{
    public class UpdateAdoptionCommandHandler : IRequestHandler<UpdateAdoptionCommandRequest, UpdateAdoptionCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateAdoptionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateAdoptionCommandResponse> Handle(UpdateAdoptionCommandRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Adoption? adoption = await _context.Adoptions.FirstOrDefaultAsync(x => x.Id.ToString() == request.AdoptionId);

            if (adoption is not null)
            {
                adoption.AdoptionNotes = request.AdoptionNotes;
                adoption.AdoptionStatus = request.AdoptionStatus;

                await _context.SaveChangesAsync();

                return new UpdateAdoptionCommandResponse
                {
                    IsSuccess = true
                };
            }
            else return new UpdateAdoptionCommandResponse { IsSuccess = false };
        }
    }
}

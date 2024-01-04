using HappyPaws.Application.Features.Commands.Adoption.UpdateAdoption;
using HappyPaws.Persistence.Contexts;
using MediatR;
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
            try
            {
                var Adoption = await _context.Adoptions.FindAsync(Guid.Parse(request.Id));

                if (Adoption == null)
                {
                    return new UpdateAdoptionCommandResponse { IsSuccess = false };
                }

                Adoption.AdoptionNotes = request.AdoptionNotes;
                Adoption.AdoptionStatus = request.AdoptionStatus;


                await _context.SaveChangesAsync();

                return new UpdateAdoptionCommandResponse { IsSuccess = true };
            }
            catch (Exception)
            {
                return new UpdateAdoptionCommandResponse { IsSuccess = false };
            }
        }
    }
}

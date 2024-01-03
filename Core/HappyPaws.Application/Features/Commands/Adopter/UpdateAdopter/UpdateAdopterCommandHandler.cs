using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Persistence.Contexts;

namespace HappyPaws.Application.Features.Commands.Adopter.UpdateAdopter
{
    public class UpdateAdopterCommandHandler : IRequestHandler<UpdateAdopterCommandRequest, UpdateAdopterCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateAdopterCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateAdopterCommandResponse> Handle(UpdateAdopterCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var adopter = await _context.Adopters.FindAsync(Guid.Parse(request.AdopterId));

                if (adopter == null)
                {
                    return new UpdateAdopterCommandResponse { IsSuccess = false };
                }

                adopter.FirstName = request.FirstName;
                adopter.LastName = request.LastName;
                adopter.Email = request.Email;
                adopter.PhoneNumber = request.PhoneNumber;

                await _context.SaveChangesAsync();

                return new UpdateAdopterCommandResponse { IsSuccess = true };
            }

            catch (Exception)
            {
                return new UpdateAdopterCommandResponse { IsSuccess = false };
            }
        }
    }
}

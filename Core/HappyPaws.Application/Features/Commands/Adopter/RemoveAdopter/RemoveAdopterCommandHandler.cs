using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Persistence.Contexts;

namespace HappyPaws.Application.Features.Commands.Adopter.RemoveAdopter
{
    public class RemoveAdopterCommandHandler : IRequestHandler<RemoveAdopterCommandRequest, RemoveAdopterCommandResponse>
    {
        public async Task<RemoveAdopterCommandResponse> Handle(RemoveAdopterCommandRequest request, CancellationToken cancellationToken)
        {
            var removeAdopter = ApplicationDbContext.AdopterList.FirstOrDefault(x => x.Id == request.AdopterId);
            ApplicationDbContext.AdopterList.Remove(removeAdopter);

            return new RemoveAdopterCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}

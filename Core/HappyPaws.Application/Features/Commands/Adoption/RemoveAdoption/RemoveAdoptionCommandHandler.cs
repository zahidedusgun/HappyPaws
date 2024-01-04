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
        public async Task<RemoveAdoptionCommandResponse> Handle(RemoveAdoptionCommandRequest request, CancellationToken cancellationToken)
        {
            var removeAdoption =
                ApplicationDbContext.AdoptionList.FirstOrDefault(adoption =>
                    adoption.Id == request.Id);
            ApplicationDbContext.AdoptionList.Remove(removeAdoption);
            return new RemoveAdoptionCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}

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
        public async Task<CreateAdoptionCommandResponse> Handle(CreateAdoptionCommandRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.AdoptionList.Add(new()
            {
                AdoptionDate = DateTime.Now,
                AdoptionNotes = request.AdoptionNotes,
                AdoptionStatus = request.AdoptionStatus,
            });

            return new CreateAdoptionCommandResponse
            {
                IsSuccess = true,
                AdoptionId = id
            };
        }
    }
}

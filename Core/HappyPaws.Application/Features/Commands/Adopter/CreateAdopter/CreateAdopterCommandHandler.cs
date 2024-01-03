using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;

namespace HappyPaws.Application.Features.Commands.Adopter.CreateAdopter
{
    public class CreateAdopterCommandHandler : IRequestHandler<CreateAdopterCommandRequest, CreateAdopterCommandResponse>
    {
        public async Task<CreateAdopterCommandResponse> Handle(CreateAdopterCommandRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.AdopterList.Add(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            });

            return new CreateAdopterCommandResponse
            {
                IsSuccess = true,
                AdopterId = id
            };
        }
    }
}

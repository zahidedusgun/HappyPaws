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
            var removeAdoption =
                _context.Adoptions.FirstOrDefault(adoption =>
                    adoption.Id == request.Id);
            _context.Adoptions.Remove(removeAdoption);
            return new RemoveAdoptionCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}

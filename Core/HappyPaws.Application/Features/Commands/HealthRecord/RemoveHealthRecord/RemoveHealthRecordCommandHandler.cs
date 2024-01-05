using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Persistence.Contexts;
using MediatR;

namespace HappyPaws.Application.Features.Commands.HealthRecord.RemoveHealthRecord
{
    public class RemoveHealthRecordCommandHandler:IRequestHandler<RemoveHealthRecordCommandRequest, RemoveHealthRecordCommandResponse> 
    {
        private readonly ApplicationDbContext _context;

        public RemoveHealthRecordCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RemoveHealthRecordCommandResponse> Handle(RemoveHealthRecordCommandRequest request, CancellationToken cancellationToken)
        {
            var removeHealthRecord =
                _context.HealthRecords.FirstOrDefault(hr =>
                    hr.Id == request.Id);
            _context.HealthRecords.Remove(removeHealthRecord);
            return new RemoveHealthRecordCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}

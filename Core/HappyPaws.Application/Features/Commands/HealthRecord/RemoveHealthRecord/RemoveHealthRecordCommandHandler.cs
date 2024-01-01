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
        public async Task<RemoveHealthRecordCommandResponse> Handle(RemoveHealthRecordCommandRequest request, CancellationToken cancellationToken)
        {
            var removeHealthRecord =
                ApplicationDbContext.HealthRecordList.FirstOrDefault(hr =>
                    hr.Id == request.Id);
            ApplicationDbContext.HealthRecordList.Remove(removeHealthRecord);
            return new RemoveHealthRecordCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}

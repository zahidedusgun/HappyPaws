using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HappyPaws.Application.Features.Queries.HealthRecord.GetAllHealthRecord
{
    public class GetAllHealthRecordQueryRequest: IRequest<List<GetAllHealthRecordQueryResponse>>
    {

    }
}

using HappyPaws.Application.Features.Queries.Adopter.GetAllAdopter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HappyPaws.Application.Features.Queries.Adopter.GetAllAdopter
{
    public class GetAllAdopterQueryRequest : IRequest<List<GetAllAdopterQueryResponse>>
    {

    }
}

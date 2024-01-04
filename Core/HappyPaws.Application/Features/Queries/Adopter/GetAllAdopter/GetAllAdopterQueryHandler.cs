﻿using HappyPaws.Application.Features.Queries.Adopter.GetAllAdopter;
using HappyPaws.Persistence.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Domain.Identity;

namespace HappyPaws.Application.Features.Queries.Adopter.GetAllAdopter
{
    public class GetAllAdopterQueryHandler : IRequestHandler<GetAllAdopterQueryRequest, List<GetAllAdopterQueryResponse>>
    {
        public async Task<List<GetAllAdopterQueryResponse>> Handle(GetAllAdopterQueryRequest request, CancellationToken cancellationToken)
        {
            return ApplicationDbContext.AdopterList.Select(adopter => new GetAllAdopterQueryResponse
            {
                FirstName = adopter.FirstName,
                LastName = adopter.LastName,
                Email = adopter.Email,
                PhoneNumber = adopter.PhoneNumber

            }).ToList();
        }
    }

}
      


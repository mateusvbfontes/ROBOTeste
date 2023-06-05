using MediatR;
using RoboContext.Application.Commands;
using RoboContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboContext.Application.Queries
{
    public class GetRoboStateQueryHandler : IRequestHandler<GetRoboStateQuery, BaseResponse<RoboService>>
    {
        private readonly RoboService _roboService;

        public GetRoboStateQueryHandler(RoboService roboService)
        {
            _roboService = roboService;
        }

        public async Task<BaseResponse<RoboService>> Handle(GetRoboStateQuery request, CancellationToken cancellationToken)
        {
            if (_roboService is not null) 
            {
                return new BaseResponse<RoboService>(true, "Successfully fetched data", null, _roboService);
            }
            else
            {
                return new BaseResponse<RoboService>(false, "", new List<string>() { "Couldn't fetch data" }, null);

            }
        }
    }
}

using MediatR;
using RoboContext.Domain.Entities;
using RoboContext.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboContext.Application.Commands
{
    public class MoveRoboCommand : IRequest<BaseResponse<RoboService>>
    {
        public RoboDTO Robo { get; set; }
        
    }
}

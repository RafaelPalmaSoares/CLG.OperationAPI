using AutoMapper;
using CLG.OperationAPI.Application.CommandHandler;
using CLG.OperationAPI.Application.Commands.Request;
using CLG.OperationAPI.Application.Models;

namespace CLG.OperationAPI.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AddOperationRequest, Operation>().ReverseMap();
        }
    }
}

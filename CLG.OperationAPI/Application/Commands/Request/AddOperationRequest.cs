using CLG.OperationAPI.Application.Commands.Response;
using CLG.OperationAPI.Application.Models;
using MediatR;

namespace CLG.OperationAPI.Application.Commands.Request
{
    public class AddOperationRequest : IRequest<AddOperationResponse>
    {
        public string? Description { get; set; }
        public double ValueOperation { get; set; }
        public int TypeOperation { get; set; }
    }
}

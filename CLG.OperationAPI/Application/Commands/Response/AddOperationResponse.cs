using CLG.OperationAPI.Application.Models;
using Microsoft.AspNetCore.Identity;

namespace CLG.OperationAPI.Application.Commands.Response
{
    public class AddOperationResponse
    {
        public List<Operation> DailyOperations { get; set; }
        public double DailyTotal { get; set; }
    }
}

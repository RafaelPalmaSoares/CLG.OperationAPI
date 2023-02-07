using AutoMapper;
using CLG.OperationAPI.Application.Commands.Request;
using CLG.OperationAPI.Application.Commands.Response;
using CLG.OperationAPI.Application.Models;
using CLG.OperationAPI.Application.Repositories;
using MediatR;
using System;

namespace CLG.OperationAPI.Application.CommandHandler
{
    public class AddOperationCommandHandler : IRequestHandler<AddOperationRequest, AddOperationResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Operation> _repository;
        private readonly IMapper _mapper;

        public AddOperationCommandHandler(IMediator mediator, IRepository<Operation> repository, IMapper mapper)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<AddOperationResponse> Handle(AddOperationRequest request, CancellationToken cancellationToken)
        {
            if (request.TypeOperation > 1 || request.TypeOperation < 0)
                return null;

            if (request.TypeOperation.Equals(Convert.ToInt32(TypeOperation.Debit)))
                request.ValueOperation = request.ValueOperation * -1;
                  

            //request.TypeOperation = Convert.ToInt32(TypeOperation.Debit);
            await _repository.AddOperation(_mapper.Map<Operation>(request));


            var dailyResult = await _repository.GetDailyReport(DateTime.Now);
            var total = dailyResult.Sum(x => x.ValueOperation);

            return new AddOperationResponse { DailyOperations = dailyResult, DailyTotal = total };
        }
    }
}

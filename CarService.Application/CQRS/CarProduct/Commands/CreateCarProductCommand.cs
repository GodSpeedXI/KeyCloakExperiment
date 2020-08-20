using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Application.CQRS.CarProduct.Queries.GetCarProduct;
using CarService.Application.Interfaces.Repositories;
using MediatR;

namespace CarService.Application.CQRS.CarProduct.Commands
{
    public class CreateCarProductCommand : IRequest<GetCarProductQueryModel>
    {
        public string Brand { get; set; }
        public string Series { get; set; }
        public string Nickname { get; set; }
    }

    public class CreateCarProductCommandHandler : IRequestHandler<CreateCarProductCommand, GetCarProductQueryModel>
    {
        private readonly ICarProductRepository _carProductRepository;
        private readonly IMapper _mapper;

        public CreateCarProductCommandHandler(ICarProductRepository carProductRepository, IMapper mapper)
        {
            _carProductRepository = carProductRepository;
            _mapper = mapper;
        }
        public async Task<GetCarProductQueryModel> Handle(CreateCarProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.CarProduct>(request);
            await _carProductRepository.AddAsync(product);
            return _mapper.Map<GetCarProductQueryModel>(product);
        }
    }
}

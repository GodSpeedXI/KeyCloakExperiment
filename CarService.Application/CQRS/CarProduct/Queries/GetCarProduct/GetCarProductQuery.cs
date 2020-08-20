using AutoMapper;
using CarService.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarService.Application.CQRS.CarProduct.Queries.GetCarProduct
{
    public class GetCarProductQuery : IRequest<IEnumerable<GetCarProductQueryModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetCarQueryHandler : IRequestHandler<GetCarProductQuery, IEnumerable<GetCarProductQueryModel>>
    {
        private readonly ICarProductRepository _carProductRepository;
        private readonly IMapper _mapper;

        public GetCarQueryHandler(ICarProductRepository carProductRepository, IMapper mapper)
        {
            _carProductRepository = carProductRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetCarProductQueryModel>> Handle(GetCarProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _carProductRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
            var productQueryModel = _mapper.Map<IEnumerable<GetCarProductQueryModel>>(product);
            return productQueryModel as IEnumerable<GetCarProductQueryModel>;
        }
    }
}

using AutoMapper;
using Discount.Appliclication.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Appliclication.Handlers.Queries
{
    internal class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, CouponModel>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;

        public GetDiscountQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            this._discountRepository = discountRepository;
            this._mapper = mapper;
        }
        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _discountRepository.GetDiscount(request.ProductName);
            if (coupon == null)
            {
                throw new Exception($"Discount with product name {request.ProductName} not found.");
            }
            var mapped = _mapper.Map<CouponModel>(coupon);
            return mapped;
        }
    }
}

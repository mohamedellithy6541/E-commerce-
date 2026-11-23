using AutoMapper;
using Discount.Appliclication.Commands;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Appliclication.Handlers.Command
{
    public class CreateDisountommandHandler : IRequestHandler<CreateDiscountCommand, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public CreateDisountommandHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            this._discountRepository = discountRepository;
            this._mapper = mapper;
        }
        public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(request);
            var createdCoupon = await _discountRepository.CreateDiscount(coupon);

            if (createdCoupon != true)
            {
                return null;
            }
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
    }
}

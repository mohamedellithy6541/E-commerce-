using AutoMapper;
using Discount.Appliclication.Handlers.Command;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Appliclication.Commands
{
    internal class UpdateDisountCommandHandler
        : IRequestHandler<UpdateDiscountCommand, CouponModel>
    {
        private readonly IMapper mapper;
        public IDiscountRepository _discountRepository { get; }

        public UpdateDisountCommandHandler(IDiscountRepository discountRepository,IMapper mapper)
        {
            _discountRepository = discountRepository;
            this.mapper = mapper;
        }


        public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = mapper.Map<Coupon>(request);
            await _discountRepository.UpdateDiscount(coupon);
            var couponModel = mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
    }
}

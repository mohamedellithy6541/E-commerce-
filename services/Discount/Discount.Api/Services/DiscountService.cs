using Discount.Appliclication.Commands;
using Discount.Appliclication.Handlers.Command;
using Discount.Appliclication.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Api.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IMediator _mediator;

        public DiscountService(IMediator mediator)
        {
            this._mediator = mediator;
        }
        public override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var query = new GetDiscountQuery(request.ProductName);
            var result = _mediator.Send(query);
            return result;
        }
        public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var command = new CreateDiscountCommand
            {
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };

            var result = _mediator.Send(command);
            return result;
        }
        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var command = new UpdateDiscountCommand
            {
                Id = request.Coupon.Id,
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };
            var result = _mediator.Send(command);
            return result;
        }
        
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var command = new DeleteDiscountCommand(request.ProductName);
            var result = await _mediator.Send(command);
            var response = new DeleteDiscountResponse()
            {
                Success = result
            };
            return response;
        }
    }
}

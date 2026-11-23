using Discount.Appliclication.Commands;
using Discount.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Appliclication.Handlers.Command
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, bool>
    {
        private readonly IDiscountRepository _discountRepository;

        public DeleteDiscountCommandHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _discountRepository.GetDiscount(request.ProductName);

            if (coupon == null)
                throw new InvalidOperationException("Discount not found");

           var deleted = await _discountRepository.DeleteDiscount(coupon.ProductName);

            return deleted;
        }
    }
}

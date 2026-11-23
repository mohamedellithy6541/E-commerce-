using AutoMapper;
using Discount.Appliclication.Commands;
using Discount.Appliclication.Handlers.Command;
using Discount.Core.Entities;
using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Appliclication.Mappers
{
    public class DiscountProile:Profile
    {
        public DiscountProile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
            CreateMap<Coupon, CreateDiscountCommand>().ReverseMap();
            CreateMap<Coupon, UpdateDiscountCommand>().ReverseMap();
        }
    }
}

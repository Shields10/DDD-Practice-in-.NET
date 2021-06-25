using AutoMapper;
using PaymentOrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentOrderSolution.AutoMapperConfig
{
    public class PaymentOrderProfile : Profile
    {
            public PaymentOrderProfile ()
        {
            CreateMap<PaymentOrder, PaymentOrderDTO>();
            CreateMap<PaymentOrderDTO, PaymentOrder>();
        }
    }
}
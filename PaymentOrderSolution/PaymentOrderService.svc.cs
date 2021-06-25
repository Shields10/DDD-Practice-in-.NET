
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutoMapper;
using PaymentOrderData;
using PaymentOrderModel;
    
namespace PaymentOrderSolution
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ApplicationErrorHandlerAttribute] // Manage all unhandled exceptions

    [UnityInstanceProviderServiceBehavior] // Create instance and inject dependencies using unity container
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PaymentOrderService : IPaymentOrderService
    {

        private readonly IPaymentOrderData<PaymentOrder> _paymentOrder;
        private readonly IMapper _mapper;

        public PaymentOrderService (IPaymentOrderData<PaymentOrder> paymentOrder, IMapper mapper)
        {
            _mapper = mapper;
            _paymentOrder = paymentOrder;
        }

        public IEnumerable<PaymentOrderDTO> GetPaymentOrder()
        {
            var data = _paymentOrder.GetAll();
        
            return _mapper.Map<IEnumerable<PaymentOrderDTO>>(data);

        }
        public void Add(PaymentOrderDTO entity)
        {
            entity.OriginatorConversationId = Guid.NewGuid();
            entity.RouteId = Guid.NewGuid();
            entity.SystemTraceAuditNumber = Guid.NewGuid();
            entity.Reference = "STM_" + RandomString(3) + "_" + RandomString(4);
            entity.PrimaryAccountNumber = entity.RecepientPhoneNumber.ToString();
            _paymentOrder.Add(_mapper.Map<PaymentOrder>(entity));

        }

        public PaymentOrderDTO Get(int Id)
        {
            var data = _paymentOrder.Get(Id);
            return _mapper.Map<PaymentOrderDTO>(data);
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }


        public void Remove(PaymentOrderDTO entity)
        {
            _paymentOrder.Remove(_mapper.Map<PaymentOrder>(entity));
        }

        public void Update(PaymentOrderDTO entity)
        {
            _paymentOrder.Update(_mapper.Map<PaymentOrder>(entity));
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



    }
}

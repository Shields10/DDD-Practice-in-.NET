using PaymentOrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace PaymentOrderSolution


{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPaymentOrderService
    {

        [OperationContract]
         IEnumerable<PaymentOrderDTO> GetPaymentOrder();

        [OperationContract]
        PaymentOrderDTO Get(int Id);
        [OperationContract]
        void Add(PaymentOrderDTO entity); 

        [OperationContract]
        void Remove(PaymentOrderDTO entity);

        [OperationContract]
        void Update(PaymentOrderDTO entity);


    }  
}

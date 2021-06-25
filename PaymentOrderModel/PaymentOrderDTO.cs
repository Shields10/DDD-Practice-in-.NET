using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrderModel
{
   public class PaymentOrderDTO
    {
        public int Id { get; set; }
        public Guid OriginatorConversationId { get; set; }
        public string RemitterName { get; set; }
        public string RemitterAddress { get; set; }
        public int RemitterPhoneNumber { get; set; }
        public string RemitterIdType { get; set; }
        public int RemitterIdNumber { get; set; }
        public string Country { get; set; }
        public string Ccy { get; set; }
        public string FinancialInstituion { get; set; }
        public string SourceOfFunds { get; set; }
        public string PrincipalActivity { get; set; }
        public string RecepientName { get; set; }
        public int RecepientPhoneNumber { get; set; }
        public string PrimaryAccountNumber { get; set; }
        public double Amount { get; set; }
        public Guid RouteId { get; set; }
        public Guid SystemTraceAuditNumber { get; set; }
        public string Reference { get; set; }
    }
}

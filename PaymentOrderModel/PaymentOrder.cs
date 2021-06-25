using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PaymentOrderModel
{
    [DataContract]
    public class PaymentOrder
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public Guid OriginatorConversationId { get; set; }

        [DataMember(IsRequired = true)]
        public string RemitterName { get; set; }

        [DataMember]
        public string RemitterAddress { get; set; }

        [DataMember(IsRequired = true)]
        public int RemitterPhoneNumber { get; set; }


        [DataMember(IsRequired = true)]
        public string RemitterIdType { get; set; }

        [DataMember(IsRequired = true)]

        public int RemitterIdNumber { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember(IsRequired = true)]
        public string Ccy { get; set; }

        [DataMember]
        public string FinancialInstituion { get; set; }

        [DataMember]
        public string SourceOfFunds { get; set; }

        [DataMember]
        public string PrincipalActivity { get; set; }

        [DataMember(IsRequired = true)]
        public string RecepientName { get; set; }

        [DataMember(IsRequired = true)]
        public int RecepientPhoneNumber { get; set; }

        [DataMember(IsRequired = true)]
        public string PrimaryAccountNumber { get; set; }

        [DataMember(IsRequired = true)]
        public double Amount { get; set; }

        [DataMember(IsRequired = true)]
        public Guid RouteId { get; set; }

        [DataMember(IsRequired = true)]
        public Guid SystemTraceAuditNumber { get; set; }

        [DataMember(IsRequired = true)]
        public string Reference { get; set; }
    }
}

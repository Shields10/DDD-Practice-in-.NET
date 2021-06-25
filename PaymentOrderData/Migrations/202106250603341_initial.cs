namespace PaymentOrderData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginatorConversationId = c.Guid(nullable: false),
                        RemitterName = c.String(),
                        RemitterAddress = c.String(),
                        RemitterPhoneNumber = c.Int(nullable: false),
                        RemitterIdType = c.String(),
                        RemitterIdNumber = c.Int(nullable: false),
                        Country = c.String(),
                        Ccy = c.String(),
                        FinancialInstituion = c.String(),
                        SourceOfFunds = c.String(),
                        PrincipalActivity = c.String(),
                        RecepientName = c.String(),
                        RecepientPhoneNumber = c.Int(nullable: false),
                        PrimaryAccountNumber = c.String(),
                        Amount = c.Double(nullable: false),
                        RouteId = c.Guid(nullable: false),
                        SystemTraceAuditNumber = c.Guid(nullable: false),
                        Reference = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentOrders");
        }
    }
}

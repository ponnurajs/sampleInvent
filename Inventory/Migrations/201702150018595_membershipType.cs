namespace Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        Discount = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MemberShipId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "membershipType_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "membershipType_Id");
            AddForeignKey("dbo.Customers", "membershipType_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipType_Id" });
            DropColumn("dbo.Customers", "membershipType_Id");
            DropColumn("dbo.Customers", "MemberShipId");
            DropTable("dbo.MembershipTypes");
        }
    }
}

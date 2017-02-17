namespace Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatemembershiptype : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes(Id, Name, SignUpFee, DurationInMonth, Discount) values(1, 'pay as you go', 0,0,0)");
            Sql("insert into MembershipTypes(Id, Name, SignUpFee, DurationInMonth, Discount) values(2, 'Monthly', 30,1,10)");
            Sql("insert into MembershipTypes(Id, Name, SignUpFee, DurationInMonth, Discount) values(3, 'Quaterly', 90,3,15)");
            Sql("insert into MembershipTypes(Id, Name, SignUpFee, DurationInMonth, Discount) values(4, 'Yealy', 300,12,20)");

        }
        
        public override void Down()
        {
        }
    }
}

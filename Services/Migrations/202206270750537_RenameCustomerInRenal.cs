namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCustomerInRenal : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Costumer_Id", newName: "Customer_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_Costumer_Id", newName: "IX_Customer_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rentals", name: "IX_Customer_Id", newName: "IX_Costumer_Id");
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "Costumer_Id");
        }
    }
}

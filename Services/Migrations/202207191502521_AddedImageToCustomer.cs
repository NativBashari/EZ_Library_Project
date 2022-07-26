namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Image");
        }
    }
}

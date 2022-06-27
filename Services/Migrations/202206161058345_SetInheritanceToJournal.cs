namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetInheritanceToJournal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PrintDate", c => c.DateTime());
            AddColumn("dbo.Products", "Topic", c => c.Int());
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discriminator");
            DropColumn("dbo.Products", "Topic");
            DropColumn("dbo.Products", "PrintDate");
        }
    }
}

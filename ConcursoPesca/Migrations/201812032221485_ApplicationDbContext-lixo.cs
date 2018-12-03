namespace ConcursoPesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationDbContextlixo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "lixo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "lixo");
        }
    }
}

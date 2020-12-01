namespace Websitebanhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Role_COlum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHangs", "Role");
        }
    }
}

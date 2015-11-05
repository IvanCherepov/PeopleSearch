namespace PeopleSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlternateText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "AlternateText", c => c.String(maxLength: 100));
            AlterColumn("dbo.People", "Picture", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Picture", c => c.Binary());
            DropColumn("dbo.People", "AlternateText");
        }
    }
}
